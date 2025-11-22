using UnityEngine;
using System.Collections; //Enable using of coroutines (work by encapsulating methods which have a return type of IEnumerator)

public class BGMController : MonoBehaviour
{
    private AudioSource bgmSource;
    public float fadeDuration = 2f; //Time taken to fade out the music

    void Awake()
    {
        bgmSource = GetComponent<AudioSource>();
    }

    //A function which can call from a Ui button to fade out the music
    public void FadeOutBGM()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float startVolume = bgmSource.volume;// record the starting colume (to know how much to reduce)

        // Gradually reduce volume
        while (bgmSource.volume > 0) //keep reducing the volume when it's > 0 (while loops)
        {
            bgmSource.volume -= startVolume * Time.deltaTime / fadeDuration; //Time.deltaTime = time between frames, decrease the colume a tiny bit every frame
            yield return null;
        }

        bgmSource.Stop(); // Stop the music after volume is 0
        bgmSource.volume = startVolume; // Reset volume when next play begin
        Debug.Log("BGM faded out and stopped");
    }
}
