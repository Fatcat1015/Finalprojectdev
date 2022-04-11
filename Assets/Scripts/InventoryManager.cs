using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InventoryManager : MonoBehaviour
{
    GameObject collected_obj;
    public bool Knife;
    public bool Matches;
    public bool SilverCoin;
    public bool Balloon;
    //public bool Balloon;

    private BoxCollider2D cursor;

    private void Start()
    {
        cursor = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//make object follow mouse
    }

    private void OnTriggerStay2D(Collider2D collision)//when collided with collectible
    {
        if (collision.tag == "Collectible")
        {
            if (Input.GetKey(KeyCode.Mouse0)) //LEFT MOUSE BUTTON PRESSED
            {
                collected_obj = collision.gameObject;
                CollectObject();
            }
        }
            
    }

    public void CollectObject()
        {
            switch (collected_obj.name)
            {
                case "Knife":
                    Knife = true;
                    break;

                case "Matches":
                    Matches = true;
                    break;

                case "SilverCoin":
                    SilverCoin = true;
                    break;

                case "Balloon":
                    Balloon = true;
                    break;

                default:
                    break;
            }
        Destroy(collected_obj);
        collected_obj = null;

    }
}
