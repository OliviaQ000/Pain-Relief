using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// needed for load scenes


public class LoadScene : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
         SceneManager.LoadScene(sceneName);
    }
}
