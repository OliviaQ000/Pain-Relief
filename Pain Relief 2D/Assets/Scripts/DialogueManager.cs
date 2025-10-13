using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText;     
    public TMP_Text dialogueText; 

    public Animator animator;

    [Header("Typing Settings")]
    public float typingSpeed = 0.03f;

    //Queue: FIFO(first in first out) collection
    private Queue<string> sentences; //Put all the sentences that want to display in this queue, when player read through the dialogue, will load new sentences from the end of the queue.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear(); //clear all sentences from previous conversation 

        foreach (string sentence in dialogue.sentences) //go through all the strings and add them to queue
        {
            sentences.Enqueue(sentence);
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

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //if type sentence is already running, it will stop and begin a new one
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        //look through all individual characters in sentence.
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text +=  letter; //append letter to end of the string
            yield return new WaitForSeconds(typingSpeed);
        } 
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
