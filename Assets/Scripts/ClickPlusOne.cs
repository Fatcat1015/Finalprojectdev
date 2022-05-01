using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPlusOne : MonoBehaviour
{
    // this script needs to be on a 3d text object
    // the object also needs to have a 2d box collider
    //3d collider would not work

    public int number = 0;

    TextMesh textMesh;
    void Start()
    {
        GetComponent<TextMesh>().text = number.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    GameObject GetTarget()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, target);
        if (hit)
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    private void OnMouseOver()
    //only works when in the zone
    {
        if (Input.GetMouseButtonDown(0)) //Left
        {
            GameObject hit = GetTarget();

            if (hit != null)
            {
                if (number <= 9)
                {
                    number++;


                }
                if (number > 9)
                {
                    number = 0;

                }
                GetComponent<TextMesh>().text = number.ToString();
            }
        }
    }
}
