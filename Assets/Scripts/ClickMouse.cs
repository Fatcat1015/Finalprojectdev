using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMouse : MonoBehaviour
{
    //public InventoryManager inventoryManager;
    InventoryManager inventoryManager;
    GameObject collected_obj;
    private BoxCollider2D cursor;

    private void Start()
    {
        cursor = GetComponent<BoxCollider2D>();
        GetComponent<BoxCollider2D>().isTrigger = true;
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//make object follow mouse
    }


    public void OnTriggerStay2D(Collider2D collision)//when collided with collectible
    {
        if (collision.tag == "Collectable")
        {
            if (Input.GetKey(KeyCode.Mouse0)) //LEFT MOUSE BUTTON PRESSED
            {
                Debug.Log("mouse pressed");
                collected_obj = collision.gameObject;
                Debug.Log("object assigned");
                inventoryManager.CollectObject();
                Debug.Log("running function");
            }
        }
    }
}