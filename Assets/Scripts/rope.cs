using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    public GameObject ii;
    public GameObject iii;

    public GameObject item;

    private void Start()
    {
        item.SetActive(false);
    }
    void Update()
    {
        if(ii!= null && iii != null)
        {
            if (ii.GetComponent<InteractScript>().interacted && iii.GetComponent<InteractScript>().interacted)
            {
                item.SetActive(true);
            }
        }
        
    }
}
