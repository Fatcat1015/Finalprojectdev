using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCoroutine : MonoBehaviour
{
    //bool clicked = false;
    public Vector3 pointA = new Vector3(34.6f, 0.5f, 0);
    public Vector3 pointB = new Vector3(36, 5, 0);
    // Start is called before the first frame update

    public AudioSource myAudioSource;
    IEnumerator Position()
    {

        //Vector3 pointA = transform.position;
        float duration = 3f;
        SpriteRenderer theSprite = GetComponent<SpriteRenderer>();
        theSprite.drawMode = SpriteDrawMode.Sliced;

        //while (clicked)
        {



            for (float t = 0f; t < 1f; t += Time.deltaTime / duration)
            {

                transform.position = Vector3.Lerp(pointA, pointB, t);

                theSprite.size -= new Vector2(0.005f, 0.005f);
                yield return 0;
            }
            //transform.position = pointB;


        }
    }
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame

    //private void onMouseDown() {

    //    if (Input.GetMouseButtonDown(0))
    //    {

    //        clicked = true;
    //    }


    //}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Position());

            myAudioSource.Play();

        }

        //onMouseDown();
        //if (clicked)
        //{
        //    Vector3 mousePos;
        //    mousePos = Input.mousePosition;
        //    mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //}
    }
}
