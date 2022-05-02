using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class FlagPiece : MonoBehaviour
{
    public bool moving;
    public int index;

    public bool finished;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            moving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moving = false;
        }
    }

    private void OnMouseDrag()
    {
        if (!finished)
        {
            if (moving)
            {
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            }
        }
        
    }

    private void OnMouseUp()
    {
        transform.parent.GetComponent<flagpuzzleGM>().PutdownFlag(gameObject);
    }
}
