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
        CheckForFurniture();
    }


    public void CheckForFurniture()
    {
        RaycastHit2D ray = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (ray.collider != null)
        {
            Debug.Log(ray.collider.tag);
            if (ray.collider.tag == "FurnitureInteract")//click on furniture to interact (for example: opening drawerscabinets)
            {

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("clicked");


                    if (!ray.collider.gameObject.GetComponent<FurnitureInteractive>().open)
                    {

                        ray.collider.gameObject.GetComponent<FurnitureInteractive>().open = true;
                        Debug.Log(ray.collider.gameObject.GetComponent<FurnitureInteractive>().open);



                        //This turns the image of the interior object on.
                        //SpriteRenderer interiorRenderer = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
                        //interiorRenderer.enabled = true;

                        if (ray.collider.gameObject.GetComponent<FurnitureInteractive>().hasChild)
                        {
                            ray.collider.gameObject.GetComponent<FurnitureInteractive>().makeChildVisible();
                        }


                        //This is to get access to the gameobject
                        //Transform interiorTransform = collision.gameObject.GetComponentInChildren<Transform>();
                        //GameObject interiorObject = interiorTransform.gameObject;
                        return;
                    }

                    if (ray.collider.gameObject.GetComponent<FurnitureInteractive>().open)
                    {

                        Debug.Log("now closed");
                        ray.collider.gameObject.GetComponent<FurnitureInteractive>().open = false;

                        if (ray.collider.gameObject.GetComponent<FurnitureInteractive>().hasChild)
                        {
                            ray.collider.gameObject.GetComponent<FurnitureInteractive>().makeChildInvisible();
                        }
                        return;

                    }


                }
            }
        }



    }

    public void OnTriggerStay2D(Collider2D collision)//when collided with collectable
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

        if (collision.tag == "Interact")//place item in puzzles
        {
            if (Input.GetKey(KeyCode.Mouse0) && item != null)
            {
                if (collision.gameObject.GetComponent<InteractScript>().Activatedby == item.name)
                {
                    collision.gameObject.GetComponent<InteractScript>().interacted = true;
                    Destroy(item);
                    // destroying puzzle piece from the scene

                }
            }
        }

        //if (collision.tag == "FurnitureInteract")//click on furniture to interact (for example: opening drawerscabinets)
        //{

        //    if (Input.GetKeyDown(KeyCode.Mouse0))
        //    {
        //        Debug.Log("clicked");


        //        if (!collision.gameObject.GetComponent<FurnitureInteractive>().open)
        //        {

        //            collision.gameObject.GetComponent<FurnitureInteractive>().open = true;
        //            Debug.Log(collision.gameObject.GetComponent<FurnitureInteractive>().open);



        //            //This turns the image of the interior object on.
        //            //SpriteRenderer interiorRenderer = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
        //            //interiorRenderer.enabled = true;

        //            if (collision.gameObject.GetComponent<FurnitureInteractive>().hasChild)
        //            {
        //                collision.gameObject.GetComponent<FurnitureInteractive>().makeChildVisible();
        //            }


        //            //This is to get access to the gameobject
        //            //Transform interiorTransform = collision.gameObject.GetComponentInChildren<Transform>();
        //            //GameObject interiorObject = interiorTransform.gameObject;
        //            return;
        //        }

        //        if (collision.gameObject.GetComponent<FurnitureInteractive>().open)
        //        {

        //            Debug.Log("now closed");
        //            collision.gameObject.GetComponent<FurnitureInteractive>().open = false;

        //            if (collision.gameObject.GetComponent<FurnitureInteractive>().hasChild)
        //            {
        //                collision.gameObject.GetComponent<FurnitureInteractive>().makeChildInvisible();
        //            }
        //            return;

        //        }


        //    }
        //}
    }

    public void OnTriggerEnter2D(Collider2D collision)//when collided with collectable
    {

        if (collision.tag == "FurnitureInteract")//click on furniture to interact (for example: opening drawerscabinets)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("clicked");


                if (!collision.gameObject.GetComponent<FurnitureInteractive>().open)
                {

                    collision.gameObject.GetComponent<FurnitureInteractive>().open = true;
                    Debug.Log(collision.gameObject.GetComponent<FurnitureInteractive>().open);



                    //This turns the image of the interior object on.
                    //SpriteRenderer interiorRenderer = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
                    //interiorRenderer.enabled = true;

                    if (collision.gameObject.GetComponent<FurnitureInteractive>().hasChild)
                    {
                        collision.gameObject.GetComponent<FurnitureInteractive>().makeChildVisible();
                    }


                    //This is to get access to the gameobject
                    //Transform interiorTransform = collision.gameObject.GetComponentInChildren<Transform>();
                    //GameObject interiorObject = interiorTransform.gameObject;
                    return;
                }

                if (collision.gameObject.GetComponent<FurnitureInteractive>().open)
                {

                    Debug.Log("now closed");
                    collision.gameObject.GetComponent<FurnitureInteractive>().open = false;

                    if (collision.gameObject.GetComponent<FurnitureInteractive>().hasChild)
                    {
                        collision.gameObject.GetComponent<FurnitureInteractive>().makeChildInvisible();
                    }
                    return;

                }


            }
        }

    }

    public void UseItem(GameObject item_picked)
    {
        item = item_picked;
    }
}