using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour
{
    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        StartCoroutine(FadeImage(true, ""));
    }
    public void GoToMainScene()
    {
        StartCoroutine(FadeImage(false, "intro"));
    }

    public void GoToGame()
    {
        StartCoroutine(FadeImage(false, "Main"));
    }

    public void GoToStartScene()
    {
        StartCoroutine(FadeImage(false, "StartScreen"));
    }

    public void GoToEnd()
    {
        StartCoroutine(FadeImage(false, "End"));
    }

    public void stopplaying()
    {
        //Debug.Log("!");
        Application.Quit();

    }

    IEnumerator FadeImage(bool fadeAway, string scenename)
    {
        if(img != null)img.enabled = true;
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            img.enabled = false;
            //SceneManager.LoadScene(scenename);

        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            SceneManager.LoadScene(scenename);
        }
    }
}
