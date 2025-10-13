using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplications : MonoBehaviour
{
    public void QuitBtn()
    {
        Application.Quit();
        Debug.Log("Application has Quit");
    }
   
}
