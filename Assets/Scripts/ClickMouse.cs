using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMouse : MonoBehaviour
{
    //public InventoryManager inventoryManager;
    InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        inventoryManager.CollectObject();

    }
}
