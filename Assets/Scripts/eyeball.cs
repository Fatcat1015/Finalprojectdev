using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeball : MonoBehaviour
{
    public bool on;
    public Sprite ons;
    public Sprite off;
    public bool clicked;
    private bool canclick;

    public AudioClip eyeballsfx;

    public AudioSource myAudioSource;
    bool alreadyPlayed = false;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.playOnAwake = false;
    }

    private void Update()
    {
        if (on) GetComponent<SpriteRenderer>().sprite = ons;
        else
        {
            GetComponent<SpriteRenderer>().sprite = off;
        }

        if (canclick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!clicked)
                {
                    clicked = true;
                    if (!alreadyPlayed)
                    {
                        if (myAudioSource != null)
                        {
                            myAudioSource.PlayOneShot(eyeballsfx);
                        }
                        alreadyPlayed = true;
                    }
                    else if (myAudioSource != null) myAudioSource.Stop();
                    alreadyPlayed = false;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canclick = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canclick = false;
    }
}
