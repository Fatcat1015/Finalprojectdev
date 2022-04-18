using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMouse : MonoBehaviour
{
    //public InventoryManager inventoryManager;
    //InventoryManager inventoryManager;
    GameObject collected_obj;
    private BoxCollider2D cursor;

    GameObject inventory;
    public GameObject item;

    public GameObject item_holding;
    private void Start()
    {
        cursor = GetComponent<BoxCollider2D>();
        GetComponent<BoxCollider2D>().isTrigger = true;
        inventory = GameObject.FindGameObjectWithTag("InventManager");
        
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
                collected_obj = collision.gameObject;
                inventory.GetComponent<Inventory2_0>().AddItem(collected_obj.name);
                Destroy(collected_obj);
                //inventoryManager.CollectObject();
            }
        }

        if (collision.tag == "Interact")
        {
            if (Input.GetKey(KeyCode.Mouse0)&&item != null)
            {
                if(collision.gameObject.GetComponent<InteractScript>().Activatedby == item.name)
                {
                    collision.gameObject.GetComponent<InteractScript>().interacted = true;
                    Destroy(item);
                }
            }
        }
    }

    public void UseItem(GameObject item_picked)
    {
        item = item_picked;
    }
}