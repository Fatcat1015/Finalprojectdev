using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScroll : MonoBehaviour
{

    public bool Scroll = true;
    // Update is called once per frame
    void Update()
    {

        if(Scroll)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if(transform.localPosition.y  <= 236) transform.Translate(0, 35, 0);
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (transform.localPosition.y >= -4.5198) transform.Translate(0, -35, 1);
            }
        }

        
    }
}
