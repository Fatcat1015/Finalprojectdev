using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterTetris : MonoBehaviour
{

    private bool falling = true;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
            {
                transform.position += new Vector3(1, 0, 0);
                    //move right
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
                //move left
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Tetris")
        {
            falling = false;
            
        }
    }
}
