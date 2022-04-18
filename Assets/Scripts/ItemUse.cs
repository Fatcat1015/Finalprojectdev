using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    public bool clicked_on;
    public bool Incorrect = true;
    public Vector2 initial_pos;

    private void Start()
    {
        initial_pos = GetComponentInParent<Transform>().position;
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
            clicked_on = false;
            transform.position = initial_pos;
            FindObjectOfType<InventoryScroll>().Scroll = true;
            FindObjectOfType<ClickMouse>().item = null;
        }
        else if (!clicked_on&&Incorrect)
        {
            FindObjectOfType<ClickMouse>().item = gameObject;
            FindObjectOfType<InventoryScroll>().Scroll = false;
            initial_pos = GetComponentInParent<Transform>().position;
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
