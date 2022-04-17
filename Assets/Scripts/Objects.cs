using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Objects : MonoBehaviour
{
    public bool inInventory = false;
    public bool isVisibleInScene = false;
    Inventory inventoryManager;

    public void Awake()
    {
        inventoryManager = FindObjectOfType<Inventory>();
    }
    public void EnableVisibilityInScene()
    {
        //if already visible
        if (isVisibleInScene)
            return;

        isVisibleInScene = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void DisableVisibilityInScene()
    {
        if (!isVisibleInScene)
            return;
        isVisibleInScene = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void PutObjectInInventory()
    {
        inventoryManager.AddObjectToInventory(this);
        MoveObjectFromSceneToInventory();
    }

    public void MoveObjectFromSceneToInventory()
    {
        //in here set the position of the sprite of the object so it now is over the inventory
    }

    public void MoveObjectFromInventoryToScene()
    {

    }

    //virtual: makes it so a function can be overriden by childeren classes

    //Use object: function called when object is in inventory and then used on something in the world.
    public virtual void UseObject()
    {
        Debug.Log("Object being used.");
    }
    public bool canRemoveObjectFromInventory = false;
    public void RemoveObjectFromInventory()
    {
        if (!canRemoveObjectFromInventory)
            return;

        UseObject();
        MoveObjectFromInventoryToScene();
        //in here code what happens when you use an object or remove it from the inventory
    }



}