using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class InteractScript : MonoBehaviour
{
    public Sprite before;
    public Sprite after;
    public bool interacted;
    public bool destory_once_interacted;
    public Animator ani;

    public bool drawer;
    public Vector2 opened;
    private Vector2 opened_pos;
    private Vector2 closed_pos;

    public bool requireAnother;
    public GameObject other_requirement;

    public AudioSource myAudioSource;
    public AudioClip useItemSound;

    bool alreadyPlayed = false;

    [SerializeField] private int interval = 1;

    public string Activatedby;
    void Start()
    {
        opened_pos = new Vector2(transform.position.x, transform.position.y + opened.y);
        closed_pos = transform.position;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = before;
        ani = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.playOnAwake = false;
        if (transform.childCount != 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            if(transform.childCount == 2) transform.GetChild(1).gameObject.SetActive(false);
            
        }

        if(Activatedby == "")Activatedby = null;

    }

    private void Update()
    {
        if (interacted)
        {
            if (ani != null) ani.SetBool("Activated", true);

            //drawer function
            if (drawer)
            {
                transform.position = opened_pos;
                Activatedby = null;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = after;
            }


            //
            if (requireAnother)
            {
                if (other_requirement.GetComponent<FurnitureInteractive>().open)
                {
                    if (transform.childCount != 0)
                    {

                        transform.GetChild(0).gameObject.SetActive(true);
                        StartCoroutine(transform.GetChild(0).gameObject.GetComponent<Colletable_initial>().delaybeforecollecting());
                        if (transform.childCount == 2)
                        {
                            transform.GetChild(1).gameObject.SetActive(true);
                            StartCoroutine(transform.GetChild(1).gameObject.GetComponent<Colletable_initial>().delaybeforecollecting());
                        }
                    }
                }
            }
            else

            if (transform.childCount != 0)
            {

                transform.GetChild(0).gameObject.SetActive(true);
                //StartCoroutine(transform.GetChild(0).gameObject.GetComponent<Colletable_initial>().delaybeforecollecting());
                if (transform.childCount == 2)
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                    //StartCoroutine(transform.GetChild(1).gameObject.GetComponent<Colletable_initial>().delaybeforecollecting());
                }
            }

            //using items
            if (!alreadyPlayed)
            {
                if (myAudioSource != null)
                {
                    myAudioSource.PlayOneShot(useItemSound);
                    alreadyPlayed = true;
                }
            }


            if (destory_once_interacted)
            {
                StartCoroutine(activate_once(interval));
            }
        }
        else
        {
            if (drawer)
            {
                transform.position = closed_pos;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = before;
            }
        }

    }

    private IEnumerator activate_once(int seconds)
    {

        yield return new WaitForSeconds(seconds);

        if (transform.childCount != 0)
        {
            if (requireAnother)
            {
                if (other_requirement.GetComponent<FurnitureInteractive>().open)
                {
                    GameObject child = transform.GetChild(0).gameObject;
                    child.SetActive(true);
                    
                    child.transform.SetParent(null);
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("!");
                GameObject child = transform.GetChild(0).gameObject;
                child.SetActive(true);
                if (gameObject.transform.parent != null) child.transform.SetParent(gameObject.transform.parent);
                else {
                    child.transform.SetParent(null);
                }
                Destroy(gameObject);
            }
        }
        else
        { 
            Destroy(gameObject);
        }

        yield return null;
    }
}
