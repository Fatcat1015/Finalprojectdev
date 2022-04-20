using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class FurnitureInteractive : MonoBehaviour
{
    public Sprite before;
    public Sprite after;
    public bool open = false;
    public bool hasChild;
    public GameObject childObject;

    //public string Activatedby;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = before;
    }

    private void Update()
    {
        if (open)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = after;
        }

        if (!open)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = before;
        }
    }
    public void makeChildVisible(){

        childObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void makeChildInvisible()
    {
        childObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}
