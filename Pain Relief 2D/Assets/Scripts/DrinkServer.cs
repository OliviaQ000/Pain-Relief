using UnityEngine;

public class DrinkServer : MonoBehaviour
{
    public GameObject ending_HE;   
    public GameObject ending_NE1; 
    public GameObject ending_NE2;     
    public GameObject ending_BE1; 
    public GameObject ending_BE2; 
    public GameObject ending_null;   

    public void OnServe()
    {
        GameObject selectedBase = GetSelected("Base");
        GameObject selectedEmotion = GetSelected("Emotion");
        GameObject selectedMedicine = GetSelected("Medicine");

        if (selectedBase == null || selectedEmotion == null || selectedMedicine == null)
        {
            ending_null.SetActive(true);
            Debug.Log("Please make sure you choose from each category.");
            return;
        }

        // combine the button selected to form unique identifier for the combo
        string combo = $"{selectedBase.name}_{selectedEmotion.name}_{selectedMedicine.name}";
        Debug.Log("Combination result" + combo);

        HideAllEndings();

        // go to different endings according to different combination
        switch (combo)
        {
            // ---------- HE ----------
            case "Milk_Sleepy_Painkiller":
            case "Milk_Sleepy_Vitamin C":
            case "Coffee_Sleepy_Melatonin":
            case "Tea_Sleepy_Melatonin":
                ending_HE.SetActive(true);
                Debug.Log("End: HE");
                break;

            // ---------- NE1 ----------
            case "Milk_Excited_Painkiller":
            case "Milk_Excited_Vitamin C":
            case "Coffee_Excited_Melatonin":
            case "Tea_Excited_Melatonin":
                ending_NE1.SetActive(true);
                Debug.Log("End: NE1");
                break;

            // ---------- NE2 ----------
            case "Milk_Excited_Melatonin":
            case "Coffee_Sleepy_Painkiller":
            case "Coffee_Sleepy_Vitamin C":
            case "Tea_Sleepy_Painkiller":
            case "Tea_Sleepy_Vitamin C":
                ending_NE2.SetActive(true);
                Debug.Log("End: NE2");
                break;

            // ---------- BE1 ----------
            case "Milk_Sleepy_Melatonin":
                ending_BE1.SetActive(true);
                Debug.Log("End: BE1");
                break;

            // ---------- BE2 ----------
            case "Coffee_Excited_Painkiller":
            case "Coffee_Excited_Vitamin C":
            case "Tea_Excited_Painkiller":
            case "Tea_Excited_Vitamin C":
                ending_BE2.SetActive(true);
                Debug.Log("End: BE2");
                break;

            // ---------- Unknown ----------
            default:
                Debug.Log("Unknown combo. No ending found.");
                break;
        }
    }

    // find the currently selected button in a category (according to tag)
    private GameObject GetSelected(string tag)
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag(tag);// Find all buttons that share the same tag 
        foreach (GameObject obj in buttons)//loop through each button
        {
            DrinkButton btn = obj.GetComponent<DrinkButton>(); // Get the DrinkButton component from this object
            if (btn.isSelected) // If this button's isSelected = true, return it as the selected one
                return obj;
        }
        return null; // If no button in this category is selected, return null
    }

// Disable all ending panels before showing the correct one
     private void HideAllEndings()
    {
        ending_HE.SetActive(false);
        ending_NE1.SetActive(false);
        ending_NE2.SetActive(false);
        ending_BE1.SetActive(false);
        ending_BE2.SetActive(false);
    }
}
