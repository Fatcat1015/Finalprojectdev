using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro_cutscene : MonoBehaviour
{
    public List<GameObject> Slides = new List<GameObject>();

    private void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            Slides.Add(child.gameObject);
        }

        for (int i = 1; i < Slides.Count; i++)
        {
            Slides[i].SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nextslide();
        }
    }

    void nextslide()
    {
        if (Slides.Count > 1)
        {
            Slides[1].SetActive(true);
            Destroy(Slides[0]);
            Slides.Remove(Slides[0]);
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }
}
