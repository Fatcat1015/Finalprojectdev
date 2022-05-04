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
    //public GameObject childObject;

    public List<GameObject> children = new List<GameObject>();

    public AudioSource myAudioSource;
    public bool destroy_once_activated;

    private Animator ani;
    [SerializeField] private int interval = 2;

    bool alreadyPlayed = false;

    public Transform opened;
    public Transform closed;
    //public string Activatedby;

    public bool drawer;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        if(!drawer)gameObject.GetComponent<SpriteRenderer>().sprite = before;

        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.playOnAwake = false;

        ani = GetComponent<Animator>();

        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }
    }

    private void Update()
    {
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i] == null) children.Remove(children[i]);
        }

        if (open)
        {
            if (drawer)
            {
                gameObject.transform.position = closed.position;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = after;

                if (!alreadyPlayed)
                {
                    if (myAudioSource != null)
                    {
                        myAudioSource.Play();
                    }
                    alreadyPlayed = true;
                }

                if (destroy_once_activated)
                {
                    StartCoroutine(destroy());
                   
                }
                else
                {
                    if (children != null)
                    {
                        for (int i = 0; i < children.Count; i++)
                        {
                            if (children[i] != null) children[i].SetActive(true);
                            if (children[i].GetComponent<Colletable_initial>() != null) StartCoroutine(children[i].gameObject.GetComponent<Colletable_initial>().delaybeforecollecting());
                        }
                    }   
                }
            }

        }

        else
        {
            if (drawer)
            {
                gameObject.transform.position = opened.position;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = before;
                if (children != null)
                {
                    for (int i = 0; i < children.Count; i++)
                    {
                        if (children[i] != null) children[i].SetActive(false);
                    }
                }
                if (myAudioSource != null) myAudioSource.Stop();
                alreadyPlayed = false;
            }
        }
    }

    private IEnumerator destroy()
    {
        if(ani != null) ani.SetBool("Activate", true);
        yield return new WaitForSeconds(interval);
        if (children != null)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i] != null)
                {
                    children[i].SetActive(true);
                    StartCoroutine(children[i].gameObject.GetComponent<Colletable_initial>().delaybeforecollecting());
                    children[i].transform.SetParent(transform.parent);
                }
            }

        }
        Destroy(gameObject);
        
        yield return null;
    }
}
