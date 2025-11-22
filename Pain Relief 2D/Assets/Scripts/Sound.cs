using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] sfxClip; //an array of sound files
    public AudioSource sfxSource;

    //Play sound by index
    public void PlaySFX(int index) //receives a number(index) telling which sound to play
    {
        if(index >= 0 && index < sfxClip.Length)//the index must be 0 or bigger and must be smaller than the number of sound clips
        {
            sfxSource.PlayOneShot(sfxClip[index]);//PlayOneShot() = plays a sound once, it doesn't interruot other sounds
        }
        else
        {
            Debug.LogWarning("SFX index out of range:" + index);//if wrong index
        }
    }
}
