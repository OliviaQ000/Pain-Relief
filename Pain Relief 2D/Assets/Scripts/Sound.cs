using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] sfxClip; //store all the sound effects
    public AudioSource sfxSource;

    //Play sound by index
    public void PlaySFX(int index)
    {
        if(index >= 0 && index < sfxClip.Length)
        {
            sfxSource.PlayOneShot(sfxClip[index]);
        }
        else
        {
            Debug.LogWarning("SFX index out of range:" + index);
        }
    }
}
