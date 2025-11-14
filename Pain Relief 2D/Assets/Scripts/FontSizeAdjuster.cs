using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FontSizeAdjuster : MonoBehaviour
{
    public Scrollbar fontSizeScrollbar; // Connect in inspector
    public TMP_Text dialogueText;
    public TMP_Text sampleText;
    public float minFontSize = 16f;
    public float maxFontSize = 40f;

    void Start()
    {
        // Check change of scrollbar
        fontSizeScrollbar.onValueChanged.AddListener(OnFontSizeChanged);

        OnFontSizeChanged(fontSizeScrollbar.value); //Set to initial
    }

    void OnFontSizeChanged(float value)
    {
        dialogueText.fontSize = Mathf.Lerp(minFontSize, maxFontSize, value);
        sampleText.fontSize = Mathf.Lerp(minFontSize, maxFontSize, value);
    }
}
