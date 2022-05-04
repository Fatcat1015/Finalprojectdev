using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finalgame_GM : MonoBehaviour
{

    public GameObject mom;
    public GameObject dad;
    public GameObject grandpa;

    public GameObject mom_plate;
    public GameObject dad_plate;
    public GameObject grandpa_plate;

    public Sprite Mom_done;
    public Sprite Dad_done;
    public Sprite Grandpa_done;

    public Sprite OpenDoor;

    private bool a;
    private bool b;
    private bool c;



    private void Update()
    {
        if(mom.GetComponent<InteractScript>().interacted)
        {
            mom_plate.GetComponent<SpriteRenderer>().sprite = Mom_done;
            a = true;
        }

        if (dad.GetComponent<InteractScript>().interacted)
        {
            dad_plate.GetComponent<SpriteRenderer>().sprite = Dad_done;
            b = true;
        }

        if (grandpa.GetComponent<InteractScript>().interacted)
        {
            grandpa_plate.GetComponent<SpriteRenderer>().sprite = Grandpa_done;
            c = true;
        }

        if (a && b && c)
        {
            GetComponent<SpriteRenderer>().sprite = OpenDoor;
        }
    }
}
