using UnityEngine;
using System.Collections;

public class BGMController : MonoBehaviour
{
    private AudioSource bgmSource;
    public float fadeDuration = 2f; //Time taken to fade out the music

    void Awake()
    {
        bgmSource = GetComponent<AudioSource>();
    }

    //Call this funciton from a Ui button to fade out the music
    public void FadeOutBGM()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float startVolume = bgmSource.volume;

        // Gradually reduce volume
        while (bgmSource.volume > 0)
        {
            bgmSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        bgmSource.Stop();
        bgmSource.volume = startVolume; // Reset volume when next play begin
        Debug.Log("BGM faded out and stopped");
    }
}
