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
            this.transform.SetParent(GameObject.Find("Item_name").transform);
            transform.position = Input.mousePosition;
        }
        else
        {
            GameObject slot = FindObjectOfType<Inventory2_0>().InventorySlots[0];
            transform.position = slot.transform.position;
            this.transform.SetParent(slot.transform);
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
            //transform.position = initial_pos;
            //FindObjectOfType<InventoryScroll>().Scroll = true;
            FindObjectOfType<ClickMouse>().item = null;
        }
        else if (!clicked_on)
        {
            FindObjectOfType<ClickMouse>().item = gameObject;
            //FindObjectOfType<InventoryScroll>().Scroll = false;
            //initial_pos = GetComponentInParent<Transform>().position;
            myAudioSource.Play();
            clicked_on = true;
        }
    }

    private void OnMouseDrag()
    {
        Debug.Log("1");
        transform.position = Input.mousePosition;
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseUp()
    {
        
    }
}
