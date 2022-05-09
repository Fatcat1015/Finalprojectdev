using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScreen : MonoBehaviour
{
    public GameObject pauseScreenUI;
    public GameObject Room;
    //public bool pauseScreenActive;

    public void Awake()
    {
        pauseScreenUI.SetActive(false);
        //pauseScreenActive = false;
    }

    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC IS BEING PRESSED");
        }
        if (pauseScreenUI.activeSelf == true)
        {
            Debug.Log("pause screen UI is active");
        }
        else if (pauseScreenUI.activeSelf == false)
        {
            Debug.Log("pause screen UI is NOT ACTIVE");
        }*/

        if (pauseScreenUI.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
           pauseScreenUI.SetActive(true);
           Room.SetActive(false);
        }
        else if (pauseScreenUI.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreenUI.SetActive(false);
            Room.SetActive(true);
        }
    }
}
