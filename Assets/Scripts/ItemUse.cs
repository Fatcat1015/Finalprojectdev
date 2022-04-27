using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    public bool clicked_on;
    public bool Incorrect = true;
    public Vector2 initial_pos;

    public AudioSource myAudioSource;
    //public AudioClip selectItemSound;


    private void Start()
    {
        initial_pos = GetComponentInParent<Transform>().position;
        myAudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (clicked_on)
        {
            transform.position = Input.mousePosition;
        }
    }
    public void useObject()
    {
        if (clicked_on)
        {
            //selected sound
            myAudioSource.Play();
            //myAudioSource.PlayOneShot(selectItemSound);
            clicked_on = false;
            transform.position = initial_pos;
            FindObjectOfType<InventoryScroll>().Scroll = true;
            FindObjectOfType<ClickMouse>().item = null;
        }
        else if (!clicked_on && Incorrect)
        {
            FindObjectOfType<ClickMouse>().item = gameObject;
            FindObjectOfType<InventoryScroll>().Scroll = false;
            initial_pos = GetComponentInParent<Transform>().position;
            myAudioSource.Play();
            clicked_on = true;
        }
    }

    public void holdObject()
    {
        if (!clicked_on)
        {

        }
    }
}
