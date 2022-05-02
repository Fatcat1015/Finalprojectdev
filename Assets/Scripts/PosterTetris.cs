using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterTetris : MonoBehaviour
{

    public bool falling = true;
    public int color = 2;
    public bool match_color_above;
    public GameObject cubeabove;
    public bool matched;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("cube" + color);
    }

    void Update()
    {
        if (matched)
        {
            Destroy(gameObject);
        }

        if (falling)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
                {
                    transform.position += new Vector3(2, 0, 0);
                    //move right
                }
                else
                {
                    transform.position += new Vector3(-2, 0, 0);
                    //move left
                }
            }
        }

        GetComponent<SpriteRenderer>().sortingOrder = 110-Mathf.RoundToInt(transform.position.y*5);
        //ytop 19
        //y min12
        

        
    }

    private void FixedUpdate()
    {

        if (!falling&&!match_color_above)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
            Debug.DrawRay(transform.position, Vector3.up, Color.green);


            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<PosterTetris>() != null&& hit.collider.gameObject.GetComponent<PosterTetris>() != this)
                {
                    if (hit.collider.gameObject.GetComponent<PosterTetris>().color == this.color)
                    {
                        if (hit.collider.gameObject.GetComponent<PosterTetris>().falling == false)
                        {
                            match_color_above = true;
                            cubeabove = hit.collider.gameObject;
                        }
                    }
                }

            }
        }

        if (match_color_above)
        {
            
            RaycastHit2D down = Physics2D.Raycast(transform.position, Vector2.down);
            Debug.DrawRay(transform.position, Vector3.down, Color.blue);

            if (down.collider != null && down.collider.gameObject.GetComponent<PosterTetris>() != null)
            {
                if (down.collider.gameObject.GetComponent<PosterTetris>().color == this.color)
                {
                    if (down.collider.gameObject.GetComponent<PosterTetris>().match_color_above)
                    {
                        down.collider.gameObject.GetComponent<PosterTetris>().matched = true;
                        FindObjectOfType<TetrisGM>().clear_count += 1;
                        Destroy(down.collider.gameObject);
                        Destroy(cubeabove);
                        Destroy(gameObject);
                    }
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Tetris"))
        {
            falling = false;
            
        }
    }
}
