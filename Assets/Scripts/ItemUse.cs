using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUse : MonoBehaviour
{
    public bool clicked_on;
    public bool Incorrect = true;

    public AudioSource myAudioSource;

    //public string slot_index;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
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
            clicked_on = false;
            FindObjectOfType<ClickMouse>().item = null;
            GameObject slot = GameObject.Find(FindObjectOfType<ClickMouse>().hovering_over_slot);
            transform.position = slot.transform.position;
            this.transform.SetParent(slot.transform);
        }
        else
        {
            FindObjectOfType<ClickMouse>().item = gameObject;
            clicked_on = true;
        }
    }
}
