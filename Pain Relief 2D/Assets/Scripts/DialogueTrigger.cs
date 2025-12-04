using UnityEngine;
using System.Collections.Generic;//needed for using list<>

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogues; // drag dialogues in in inspector (Dialogue.cs is used)
    private int currentIndex = 0; //starts from the first dialogue in the list

    public void TriggerDialogue()
    {
        if (dialogues.Count == 0) return;//if there's no dialogue in list, stop the function

        Debug.Log("Button clicked, triggering dialogue...");

        //play current dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues[currentIndex]);
        //find DialogueManager in the scene, calls StartDialogue function (from DialogueManager.cs), passes the current dialogue from the list
        
        if (currentIndex < dialogues.Count - 1)
        {
            currentIndex++;
        }
        // if played all dialogue, keep playing the last one
    }

    public void ResetDialogue()
    {
        currentIndex = 0;
        TriggerDialogue();
    }
}
