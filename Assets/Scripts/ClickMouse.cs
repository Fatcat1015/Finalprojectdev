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
    public AudioSource myAudioSource;
    //public AudioClip collectItemSound;

    Camera mainCamera;

    bool interacting;
    public bool interact_furniture;
    public bool interact_others;
    FurnitureInteractive Finteractive;

    public bool waitover = true;

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
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FurnitureInteract")
        {
            interact_furniture = true;
            Finteractive = collision.gameObject.GetComponent<FurnitureInteractive>();
        }

        if (collision.tag == "Collectable" || collision.tag == "Interact")
        {
            //interact_others = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FurnitureInteract") interact_furniture = false;
        if (collision.tag == "Collectable" || collision.tag == "Interact")
        {
            interact_others = false;
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

                else if (collision.tag == "Interact")//place item in puzzles
                {
                    if (item != null)
                    {
                        if (collision.gameObject.GetComponent<InteractScript>().Activatedby == item.name)
                        {
                            collision.gameObject.GetComponent<InteractScript>().interacted = true;
                            Destroy(item);
                            StartCoroutine(waittime());
                        }
                    }
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
}