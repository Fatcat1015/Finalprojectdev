using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour
{
    public void GoToMainScene()
    {
        SceneManager.LoadScene("intro");
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void stopplaying()
    {
        //Debug.Log("!");
        Application.Quit();

    }
}
