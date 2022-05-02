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
    //public string Activatedby;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = before;
        //GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        myAudioSource = GetComponent<AudioSource>();

        ani = GetComponent<Animator>();

        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }
    }

    private void FixedUpdate()
    {
        /*for (int i = 0; i < children.Count; i++)
        {
            if (children[i] == null) children.Remove(children[i]);
        }*/
        if (open)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = after;

            if (!alreadyPlayed)
            {
                if(myAudioSource!= null)
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
                    for(int i = 0; i < children.Count; i++){
                        if (children[i] != null)children[i].SetActive(true);
                    }
            }
        }

        else
        { 
            gameObject.GetComponent<SpriteRenderer>().sprite = before;
            
                for (int i = 0; i < children.Count; i++)
                {
                    if (children[i] != null) children[i].SetActive(false);
                }
            if (myAudioSource != null) myAudioSource.Stop();
            alreadyPlayed = false;
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
                children[i].SetActive(true);
                children[i].transform.SetParent(null);
            }

        }
        Destroy(gameObject);
        
        yield return null;
    }
}
