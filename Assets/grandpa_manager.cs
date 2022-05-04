using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grandpa_manager : MonoBehaviour
{

    public bool interacted;
    public GameObject poisoned;

    public Sprite dead_grandpa;

    // Update is called once per frame
    void Update()
    {
        if (poisoned.GetComponent<InteractScript>().interacted)
        {
            interacted = true;
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            GetComponent<SpriteRenderer>().sprite = dead_grandpa;
        }
    }
}
