using UnityEngine;

public class ResetScene : MonoBehaviour

{   //Reset all the data when game is restart

    public ClickInput clickInput;
    public DialogueTrigger dialogueTrigger;

    
    private AudioSource bgmSource;//                                                        ------BGMController.cs

    
    void Awake()
    {
        bgmSource = GetComponent<AudioSource>(); //Find BGM of the scene                    ------BGMController.cs
        bgmSource.Stop(); //Make sure BGM is stopped at the very beginning to avoid interruption with gameobject "Music".
    }


   public void ResetValue()
   {

        bgmSource.Play(); // Restart BGM of the scene when the game is play twice           ------BGMController.cs

        clickInput.ResetStage(); // Reset stage of HE CG                                    ------ClickInput.cs

        dialogueTrigger.ResetDialogue(); //                                                 ------DialogueTrigger.cs
       
   }
}
