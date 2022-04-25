using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class FurnitureInteractive : MonoBehaviour
{
    public Sprite before;
    public Sprite after;
    public bool open = false;
    public bool hasChild;
    public GameObject childObject;

    public AudioSource myAudioSource;
    public bool destroy_once_activated;

    private Animator ani;

    bool alreadyPlayed = false;
    //public string Activatedby;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = before;
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        myAudioSource = GetComponent<AudioSource>();

        ani = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (open)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = after;

            if (!alreadyPlayed)
            {

                myAudioSource.Play();
                alreadyPlayed = true;
            }

            if (destroy_once_activated)
            {
                StartCoroutine(destroy());
            }
            else
            {
                if (childObject != null) childObject.SetActive(true);
            }
        }

        else
        { 
            gameObject.GetComponent<SpriteRenderer>().sprite = before;
            if (childObject != null) childObject.SetActive(false);
            myAudioSource.Stop();
            alreadyPlayed = false;

        }
    }

    private IEnumerator destroy()
    {
        if(ani != null) ani.SetBool("Activate", true);
        yield return new WaitForSeconds(1);
        childObject.SetActive(true);
        childObject.transform.SetParent(null);
        Destroy(gameObject);
        
        yield return null;
    }
}
