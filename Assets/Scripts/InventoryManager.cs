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
    public bool BalloonDeflected;
    public bool BalloonWithWater;

    public bool BalloonWithIce;
    public bool Record;
    public bool Gastube;
    public bool KettleEmpty;
    public bool KettleWithWater;

    public bool Pistol;
    public bool GlassShard;
    public bool GumUnchewed;
    public bool GumChewed;
    public bool Flag1;

    public bool Flag2;
    public bool Flag3;
    public bool Wire;
    public bool Battery1;
    public bool Battery2;

    public bool Cube;
    public bool Fish;
    public bool Bolt;
    public bool Fly;
    public bool Stamp1;

    public bool Stamp2;
    public bool Stamp3;
    public bool Stamp4;
    public bool Icecubes;
    public bool Timer;

    public bool Needle;
    public bool ScrewDriver;
    public bool Key1;
    public bool Key2;
    public bool Gin;


    // if collected
    //public bool Balloon;

    private BoxCollider2D cursor;

    private void Start()
    {
        cursor = GetComponent<BoxCollider2D>();
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//make object follow mouse
    }

    private void OnTriggerStay2D(Collider2D collision)//when collided with collectible
    {
        if (collision.tag == "Collectable")
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
            //
                case "Knife":
                    Knife = true;
                    break;

                case "Matches":
                    Matches = true;
                    break;

                case "SilverCoin":
                    SilverCoin = true;
                    break;

                case "BalloonDeflected":
                    BalloonDeflected = true;
                    break;

                case "BalloonWithWater":
                    BalloonWithWater = true;
                    break;

                case "BalloonWithIce":
                    BalloonWithIce = true;
                    break;

                case "Record":
                    Record = true;
                    break;

                case "Gastube":
                    Gastube = true;
                    break;
                
                case "KettleEmpty":
                    KettleEmpty= true;
                    break;

                case "KettleWithWater":
                    KettleWithWater= true;
                    break;

                case "Pistol":
                    Pistol= true;
                    break;

                case "GlassShard":
                    GlassShard = true;
                    break;

                case "GumUnchewed":
                    GumUnchewed= true;
                    break;

                case "GumChewed":
                    GumChewed = true;
                    break;

                case "Flag1":
                    Flag1= true;
                    break;
                
                case "Flag2":
                    Flag2 = true;
                    break;

                case "Flag3":
                    Flag3= true;
                    break;
                
                case "Wire":
                     Wire= true;
                    break;

                case "Battery1":
                    Battery1 = true;
                    break;

                case "Battery2":
                    Battery2 = true;
                    break;

                case "Cube":
                    Cube = true;
                    break;

                case "Fish":
                    Fish= true;
                    break;

                case "Bolt":
                    Bolt = true;
                    break;

                case "Fly":
                    Fly= true;
                    break;

                case "Stamp1":
                    Stamp1= true;
                    break;

                case "Stamp2":
                    Stamp2 = true;
                    break;

                case "Stamp3":
                   Stamp3  = true;
                    break;

                case "Stamp4":
                    Stamp4 = true;
                    break;

                case "Icecubes":
                     Icecubes= true;
                    break;

                case "Timer":
                    Timer = true;
                    break;

                case "Needle":
                    Needle = true;
                    break;

                case "ScrewDriver":
                    ScrewDriver = true;
                    break;

                case "Key1":
                    Key1= true;
                    break;

                case "Key2":
                    Key2 = true;
                    break;

                case "Gin":
                    Gin = true;
                    break;


            default:
                    break;
            }
        Destroy(collected_obj);
        collected_obj = null;

    }

    private void put_in_inventory(string object_name)
    {

    }
}
