using UnityEngine;
using UnityEngine.UI;

public class DrinkButton : MonoBehaviour
{
    public bool isSelected = false; // at start all the button is not selected
    private Button button;
    private Image image; // highlight when the button is selected
    private Color normalColor = Color.white;
    private Color selectedColor = new Color(0.8f, 1f, 0.8f);

    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // get all the button with same tag/category
        GameObject[] sameGroupButtons = GameObject.FindGameObjectsWithTag(gameObject.tag);

        // if more than one button in the same group is pressed, cancel the selection
        foreach (GameObject obj in sameGroupButtons)
        {
            obj.GetComponent<DrinkButton>().Deselect();
        }

        // set the pressed button as selected and highlight it
        isSelected = true;
        image.color = selectedColor;
    }

    public void Deselect()
    {
        isSelected = false;
        if (image != null)
            image.color = normalColor;
    }
}

