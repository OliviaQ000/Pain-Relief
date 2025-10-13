using UnityEngine;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogues; // drag in in inspector
    private int currentIndex = 0;

    public void TriggerDialogue()
    {
        if (dialogues.Count == 0) return;

        //play current dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues[currentIndex]);

        
        if (currentIndex < dialogues.Count - 1)
        {
            currentIndex++;
        }
        // if played all dialogue, keep playing the last one
    }
}
