using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{

    public Transform movecat;
    //bool move;

    public GameObject fish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fish!= null)
        {
            if (fish.GetComponent<InteractScript>().interacted)
            {
                transform.position = movecat.transform.position;
            }
        }
        
    }
}
