using UnityEngine;
using UnityEngine.UI;

public class DrinkButton : MonoBehaviour
{
    public bool isSelected = false; //at start all the button is not selected
    private Button button;
    private Image image; //highlight when the button is selected
    private Color normalColor = Color.white;
    private Color selectedColor = new Color(0.8f, 1f, 0.8f);//selected color is light green

    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(OnClick);//whenever this button is clicked, run the function OnClick()
    }

    void OnClick()
    {
        //find all buttons with same tag
        GameObject[] sameGroupButtons = GameObject.FindGameObjectsWithTag(gameObject.tag);

        //loop through each button in the same group, if more than one button in the same group is pressed, cancel the selection
        foreach (GameObject obj in sameGroupButtons)
        {
            obj.GetComponent<DrinkButton>().Deselect();
        }

        //set the pressed button as selected and highlight it
        isSelected = true;
        image.color = selectedColor;//change color to green
    }

    public void Deselect()//this is called when another button in the group is selected
    {
        isSelected = false;
        if (image != null)
            image.color = normalColor;
    }
}

