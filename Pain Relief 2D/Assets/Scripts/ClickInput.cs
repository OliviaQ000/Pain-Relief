using UnityEngine;
using UnityEngine.InputSystem;// Using new Input system

public class ClickInput : MonoBehaviour
{
    public GameObject canvas_environment;
    public GameObject dialoguePanel; // The UI panel to check if is active

    public GameObject Cg_HE_Knockdoor; //heStage = 1
    public GameObject Cg_HE_Enter;//heStage = 2
    public GameObject Cg_HE_Hello;//heStage = 3
    public GameObject Ending_HE; // The UI panel to check if is active

    public GameObject Button_HE;// button tranfer to HE scene

    private int heStage = 0; // "0" means not started yet

    void Update()
    {
        // Mouse click on right button: Only check click when dialogue panel is active
        if (dialoguePanel != null && dialoguePanel.activeInHierarchy) //If dialoguepanel exist and is active in hierarchy
        {
            if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
            {
                OnClick();
            }
        }



        // Mouse click on left button: Only check click when HappyEnding panel is active
        if (Ending_HE != null && Ending_HE.activeInHierarchy)
        {
            
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                HEOnClick();
            }
        }
    }

    void OnClick() //this runs when right click happens during dialogue
    {
        Debug.Log("Clicked while dialogue panel is active!");
        canvas_environment.SetActive(true);
    }

    void HEOnClick() //this runs when left clicks happens in HappyEnding panel
    {
        if (heStage == 0)
        {
            Debug.Log("You reach the HappyEnding!");
            Cg_HE_Knockdoor.SetActive(true);
            heStage = 1;
        }
        
        else if (heStage == 1)
        {
            // When knock door CG is active
            Debug.Log("Rowan comes.");
            Cg_HE_Enter.SetActive(true);
            heStage = 2;
     
        }
        
        else if (heStage == 2)
        {
            // When enter CG is active
            Debug.Log("Good morning!");
            Cg_HE_Hello.SetActive(true);
            heStage = 3;
        }
       
       else if (heStage == 3)
       {
            // When hello CG is active
            Debug.Log("Go to HappyEnding!");
            Button_HE.SetActive(true);
            heStage = 4;
       }
    }
}
