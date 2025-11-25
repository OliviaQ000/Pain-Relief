using System.Collections; //using Coroutines
using System.Collections.Generic;//needed for Queue, List, Dictionary
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText; 
    public TMP_Text dialogueText; 

    public Animator animator; //open and close dialogue window 

    [Header("Typing Settings")] //create a section in inspector
    public float typingSpeed = 0.03f;//how fast each letter appears

    //Queue: FIFO(first in first out) collection
    private Queue<string> sentences; //Put all the sentences that want to display in this queue, when player read through the dialogue, will load new sentences from the end of the queue

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting dialogue with: " + dialogue.name);

        animator.SetBool("IsOpen", true);//let animator play open animation

        nameText.text = dialogue.name;//show the NPC name

        sentences.Clear(); //clear all sentences from previous conversation 

        foreach (string sentence in dialogue.sentences) //go through all the strings
        {
            sentences.Enqueue(sentence);//Enqueue() = puts each sentence into the queue in order
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
       //check if theres more sentences in the queue
       if (sentences.Count == 0) 
       {
        EndDialogue();
        return;
       }

        string sentence = sentences.Dequeue();//Dequeue() = take the first sentence out of the queue (play the next sentence)
        StopAllCoroutines(); //if type sentence is already running, it will stop and begin a new one (avoid overlapping)
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        //clear the text first
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())//look through all individual characters in sentence.
        {
            dialogueText.text +=  letter; //append letter to end of the string
            yield return new WaitForSeconds(typingSpeed);
        } 
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);//let animator play close animation
    }
}
