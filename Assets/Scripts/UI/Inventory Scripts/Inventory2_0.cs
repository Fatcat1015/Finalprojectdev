using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory2_0 : MonoBehaviour
{
    //public List<GameObject> item = new List<GameObject>();
    public List<GameObject> InventorySlots = new List<GameObject>();
    public List<GameObject> UsedSlots = new List<GameObject>();
    public GameObject item_default;
    public GameObject InventoryUI;
    //ublic SpriteAtlas furniture1;
    void Start()
    {
        InventoryUI = GameObject.FindGameObjectWithTag("InventoryUI");
        InventoryUI.GetComponentInChildren<Transform>();
        foreach (Transform child in InventoryUI.transform)
        {
            InventorySlots.Add(child.gameObject);
        }
    }
    void Update()
    {
        //remove empty used slots into inventory slots list
        for (int i = 0; i<UsedSlots.Count;i++)
        {
            if(UsedSlots[i].transform.childCount == 0)
            {
                //InventorySlots.Add(UsedSlots[i]);
                InventorySlots.Insert(0, UsedSlots[i]);
                UsedSlots.Remove(UsedSlots[i]);
            }
        }
        //if there's an item move slot to used slots
        for(int i = 0; i < InventorySlots.Count; i++)
        {
            if (InventorySlots[i].transform.childCount != 0)
            {
                UsedSlots.Add(InventorySlots[i]);
                InventorySlots.Remove(InventorySlots[i]);
            }
        }

    }


    public void AddItem(string item_name)
    {
        GameObject newitem = Instantiate(item_default, new Vector3(0,0,0), Quaternion.identity) as GameObject;
        newitem.transform.SetParent(InventorySlots[0].transform,false);
        newitem.name = item_name;
        if (Resources.Load<Sprite>(item_name) != null)
        {
            newitem.GetComponent<Image>().sprite = Resources.Load<Sprite>(item_name);
        }
        newitem.GetComponent<ItemUse>().slot_index = InventorySlots[0].name;
        UsedSlots.Add(InventorySlots[0]);
        InventorySlots.Remove(InventorySlots[0]);
    }
}
