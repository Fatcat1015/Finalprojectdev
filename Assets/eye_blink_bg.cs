using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye_blink_bg : MonoBehaviour
{

    //public GameObject pupil;
    public float factor = 0.25f;
    public float limit = 0.12f;

    private Vector3 center;

    private void Start()
    {
        center = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        //Convert mouse pointer cords into a worldspace vector3
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.0f;

        //Create a dir target based on mouse vector * factor
        Vector3 dir = pos * factor;

        //Clamp the dir target
        dir = Vector3.ClampMagnitude(dir, limit);

        //Update the pupil position
        transform.position = center + dir;
    }
}
