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
    public bool interact_furniture;
    FurnitureInteractive Finteractive;

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

        if (interact_furniture)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!Finteractive.open)
                {
                    Finteractive.open = true;
                }
                else
                {
                    Finteractive.open = false;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FurnitureInteract")
        {
            Debug.Log("!");
            interact_furniture = true;
            Finteractive = collision.gameObject.GetComponent<FurnitureInteractive>();
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FurnitureInteract") interact_furniture = false ;
    }

    public void OnTriggerStay2D(Collider2D collision)//when collided with collectable
    {
        if(collision != null)
        {
            //Debug.Log("m");
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetMouseButtonDown(0))
            {
                if (collision.tag == "Collectable")
                {
                    collected_obj = collision.gameObject;
                    inventory.GetComponent<Inventory2_0>().AddItem(collected_obj.name);
                    Destroy(collected_obj);
                }

                else if (collision.tag == "Interact")//place item in puzzles
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
        
    }

    public void UseItem(GameObject item_picked)
    {
        item = item_picked;
    }
}