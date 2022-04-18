using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class InteractScript : MonoBehaviour
{
    public Sprite before;
    public Sprite after;
    public bool interacted;

    public string Activatedby;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = before;
    }

    private void Update()
    {
        if(interacted) gameObject.GetComponent<SpriteRenderer>().sprite = after;
    }
}
