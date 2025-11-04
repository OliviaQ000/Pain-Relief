using UnityEngine;
using UnityEngine.InputSystem;// Using new Input system

public class ClickInput : MonoBehaviour
{
    public GameObject canvas_environment;
    public GameObject dialoguePanel; // The UI panel to check

    void Update()
    {
        // Only detect click when dialogue panel is active
        if (dialoguePanel == null || !dialoguePanel.activeInHierarchy)
            return;

        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            OnClick();
        }
    }

    void OnClick()
    {
        Debug.Log("Clicked while dialogue panel is active!");
        canvas_environment.SetActive(true);
    }
}
