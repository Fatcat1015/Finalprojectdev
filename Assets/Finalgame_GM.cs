using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finalgame_GM : MonoBehaviour
{

    public GameObject mom;
    public GameObject dad;
    public GameObject grandpa;

    private void Update()
    {
        if(mom.GetComponent<InteractScript>().interacted&& dad.GetComponent<InteractScript>().interacted&& grandpa.GetComponent<InteractScript>().interacted)
        {
            Debug.Log("You are done");
        }
    }
}
