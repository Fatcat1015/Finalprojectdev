using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer : MonoBehaviour
{
    GameObject Drawer1;
    GameObject Drawer2;
    GameObject Drawer3;
    GameObject Drawer4;

    private void Start()
    {
        Drawer1 = GameObject.Find("drawer1");
        Drawer2 = GameObject.Find("drawer2");
        Drawer3 = GameObject.Find("drawer3");
        Drawer4 = GameObject.Find("drawer4");
    }

    private void Update()
    {
        if (Drawer1.GetComponent<InteractScript>().interacted&& !Drawer3.GetComponent<InteractScript>().interacted)
        {
            Drawer3.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            Drawer3.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (Drawer2.GetComponent<InteractScript>().interacted && !Drawer4.GetComponent<InteractScript>().interacted)
        {
            Drawer4.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            Drawer4.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
