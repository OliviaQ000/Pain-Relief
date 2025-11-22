using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FontSizeAdjuster : MonoBehaviour
{
    public Scrollbar fontSizeScrollbar; // Connect in inspector
    public TMP_Text dialogueText;
    public TMP_Text sampleText;
    public float minFontSize = 16f;
    public float maxFontSize = 40f; //the scrollbar will change font size between this two numbers

    void Start()
    {
        //listens for changes in the scrollbar
        fontSizeScrollbar.onValueChanged.AddListener(OnFontSizeChanged);//each time the scrollbar is moved, call the function "OnFontSizeChanged"

        OnFontSizeChanged(fontSizeScrollbar.value); //let the font size using the scrollsbar's initial value
    }

    void OnFontSizeChanged(float value)//value = number between 0 and 1 from the scrollbar
    {
        dialogueText.fontSize = Mathf.Lerp(minFontSize, maxFontSize, value);//when value = 0, fontsize = min (16). When value = 1, fontsize = max (40).
        sampleText.fontSize = Mathf.Lerp(minFontSize, maxFontSize, value);
    }
}
