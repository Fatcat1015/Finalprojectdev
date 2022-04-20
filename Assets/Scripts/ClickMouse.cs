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

    Camera mainCamera;

    bool interacting;

    private void Awake()
    {
        mainCamera = Camera.main;
        //sets the camera 
    }


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



    public void OnTriggerStay2D(Collider2D collision)//when collided with collectable
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (collision.tag == "FurnitureInteract")
            {
                if (!collision.gameObject.GetComponent<FurnitureInteractive>().open)
                {
                    collision.gameObject.GetComponent<FurnitureInteractive>().open = true;
                }
                else
                {
                    collision.gameObject.GetComponent<FurnitureInteractive>().open = false;
                }
            }

            if (collision.tag == "Collectable")
            {
                collected_obj = collision.gameObject;
                inventory.GetComponent<Inventory2_0>().AddItem(collected_obj.name);
                Destroy(collected_obj);
            }

            if (collision.tag == "Interact")//place item in puzzles
            {
                if (item != null)
                {
                    if (collision.gameObject.GetComponent<InteractScript>().Activatedby == item.name)
                    {
                        collision.gameObject.GetComponent<InteractScript>().interacted = true;
                        Destroy(item);
                    }
                }
            }
        }
    }

    public void UseItem(GameObject item_picked)
    {
        item = item_picked;
    }
}