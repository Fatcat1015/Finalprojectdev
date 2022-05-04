using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Colletable_initial : MonoBehaviour
{
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        if(GetComponent<BoxCollider2D>().enabled == false)StartCoroutine(delaybeforecollecting());
    }

    public IEnumerator delaybeforecollecting()
    {
        Debug.Log("!");
            yield return new WaitForSeconds(0.1f);
            GetComponent<BoxCollider2D>().enabled = true;
    }
}
