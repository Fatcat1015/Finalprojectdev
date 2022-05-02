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

    public string slot_index;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (clicked_on)
        {
            if (Input.GetMouseButtonDown(0))
            {
                useObject();
            }
            //transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
        else
        {
            //slot_index = GetComponentInParent<Transform>().name;
        }
    }

    public void dragobject()
    {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    public void useObject()
    {
        if (clicked_on)
        {
            //selected sound
            myAudioSource.Play();
            clicked_on = false;
            FindObjectOfType<ClickMouse>().item = null;
            StartCoroutine(returnobject());
        }
        else 
        {
            if (FindObjectOfType<ClickMouse>().item = null)transform.SetParent(GameObject.Find("Item_name").transform);
            FindObjectOfType<ClickMouse>().item = gameObject;
            clicked_on = true;
        }
    }

    IEnumerator returnobject(){
        yield return new WaitForSeconds(0.1f);
        GameObject slot = GameObject.Find(FindObjectOfType<ClickMouse>().hovering_over_slot);
        if (slot != null&& slot.transform.childCount == 0)
        {
                transform.position = slot.transform.position;
                transform.SetParent(slot.transform);
        }
        else
        {
            GameObject O_slot = GameObject.Find(slot_index);
            transform.position = O_slot.transform.position;
            transform.SetParent(O_slot.transform);
        }
    }
}
