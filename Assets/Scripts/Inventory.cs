using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<GameObject> allObjectPrefabs = new List<GameObject>();
    [HideInInspector] public List<Object> inventoryObjects = new List<Object>();
    public const int maximumInventoryAmount = 20; //amount of objects player can hold at once

    public List<Vector2> inventoryObjectPositions = new List<Vector2>();

    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//make object follow mouse
    }

    private void OnTriggerStay2D(Collider2D collision)//when collided with collectible
    {
        if (!Input.GetKey(KeyCode.Mouse0)) //if LEFT MOUSE BUTTON PRESSED
            return;

        Objects obj = collision.gameObject.GetComponent<Objects>();
        if (obj == null) //if there is an object component on the object collided with
            return;

        if (!obj.inInventory)
        {
            obj.PutObjectInInventory();
            return;
        }

        if (obj.inInventory)
        {
            obj.RemoveObjectFromInventory();
            return;
        }



    }

    public void AddObjectToInventory(Objects obj)
    {
        //check if amount of objects in inventory is greater
        //than inventory maximum
        if (inventoryObjects.Count >= maximumInventoryAmount)
            return; //return: ends function, nothing after is called

        //Continuing past inventory max check:

        obj.MoveObjectFromSceneToInventory();
        inventoryObjects.Add(obj);


    }

}