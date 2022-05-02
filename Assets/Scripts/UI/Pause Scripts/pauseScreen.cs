using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScreen : MonoBehaviour
{
    public GameObject pauseScreenUI;
    public bool pauseScreenActive = false;

    public void Start()
    {
        //pauseScreenUI.SetActive(false);
    }

    public void Update()
    {
        CheckPauseScreenActive();
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ESC is being pressed");

        }
        if (pauseScreenUI != null && !pauseScreenActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseScreenActive = true;
                pauseScreenUI.SetActive(true);
            }
        }
        else if (pauseScreenActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseScreenUI.SetActive(false);
                pauseScreenActive = false;
            }
        }*/
    }

    public void CheckPauseScreenActive()
    {
        if (!pauseScreenActive && pauseScreenUI !=null)
        {
            pauseScreenUI.SetActive(false);
        }
        else if (pauseScreenActive && pauseScreenUI != null)
        {
            pauseScreenUI.SetActive(true);
        }
    }
}
