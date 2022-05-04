using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMouse : MonoBehaviour
{
    //public InventoryManager inventoryManager;
    //InventoryManager inventoryManager;


    GameObject collected_obj;
    private BoxCollider2D cursor;

    GameObject collided_obj;

    GameObject inventory;
    public GameObject item;


    public GameObject item_holding;
    public AudioSource myAudioSource;
    //public AudioClip collectItemSound;

    Camera mainCamera;

    bool interacting;
    public bool interact_furniture;
    public bool interact_number;
    public bool interact_others;
    public bool interact_interact;
    FurnitureInteractive Finteractive;


    public bool waitover = true;

    public string hovering_over_slot;

    private GameObject interacting_num;


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
        myAudioSource = GetComponent<AudioSource>();



    }
    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//make object follow mouse

        if (interact_furniture && !interact_others)
        {
            if (Input.GetMouseButtonDown(0) && item == null)
            {
                if (!Finteractive.open && waitover)
                {
                    Finteractive.open = true;
                    StartCoroutine(waittime());
                }
                else
                {
                    if (waitover)
                    {
                        Finteractive.open = false;
                        StartCoroutine(waittime());
                    }
                }
            }
        }

        if (interact_number)
        {
            if (Input.GetMouseButtonDown(0))
            {
                interacting_num.GetComponent<ClickPlusOne>().ChangeSafeCode();
            }
        }

        if (interact_interact)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(collided_obj!= null)
                {


                    if (collided_obj.GetComponent<InteractScript>().drawer)
                    {

                        if (collided_obj.GetComponent<InteractScript>().Activatedby == null)
                        {
                            collided_obj.gameObject.GetComponent<InteractScript>().interacted = !collided_obj.gameObject.GetComponent<InteractScript>().interacted;
                        }
                        else
                        {
                            if (item != null)
                            {
                                if (collided_obj.gameObject.GetComponent<InteractScript>().Activatedby == item.name)
                                {
                                    collided_obj.gameObject.GetComponent<InteractScript>().interacted = true;
                                    Destroy(item);
                                    StartCoroutine(waittime());
                                }
                            }
                        }
                    }
                    else

                    if (item != null)
                    {
                        if (collided_obj.gameObject.GetComponent<InteractScript>().Activatedby == item.name)
                        {
                            collided_obj.gameObject.GetComponent<InteractScript>().interacted = true;
                            Destroy(item);
                            StartCoroutine(waittime());
                        }
                    }
                }
                
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FurnitureInteract")
        {
            interact_furniture = true;
            Finteractive = collision.gameObject.GetComponent<FurnitureInteractive>();
        }

        if (collision.tag == "number")
        {
            //collision.gameObject.GetComponent<ClickPlusOne>().ChangeSafeCode();
            interact_number = true;
            interacting_num = collision.gameObject;
        }

        if (collision.tag == "Interact")
        {
            interact_interact = true;
            collided_obj = collision.gameObject;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FurnitureInteract") interact_furniture = false;
        if (collision.tag == "Collectable" || collision.tag == "Interact")
        {
            interact_others = false;
        }

        if (collision.tag == "number")
        {
            interact_number = false;
            interacting_num = null;
        }

        if (collision.tag == "Interact")
        {
            interact_interact = false;
            collided_obj = null;
        }
    }


    public void OnTriggerStay2D(Collider2D collision)//when collided with collectable
    {
        if (collision != null && waitover)
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetMouseButton(0))
            {
                if (collision.tag == "Collectable")
                {
                    myAudioSource.Play();
                    collected_obj = collision.gameObject;
                    inventory.GetComponent<Inventory2_0>().AddItem(collected_obj.name);
                    Destroy(collected_obj);
                    StartCoroutine(waittime());
                }
                else if (collision.tag == "Zoom")
                {
                    RoomMovement rm = FindObjectOfType<RoomMovement>();
                    rm.zoomin(collision.gameObject.transform.GetChild(0).transform);
                }


            }




        }



    }

    public void UseItem(GameObject item_picked)
    {
        item = item_picked;
    }

    private IEnumerator waittime()
    {
        waitover = false;
        yield return new WaitForSeconds(0.25f);
        waitover = true;
    }

    public void hover(GameObject item)
    {
        hovering_over_slot = item.name;
    }

}