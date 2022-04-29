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
