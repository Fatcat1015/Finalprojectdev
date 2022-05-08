using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{

    public Transform movecat;
    bool move;
    bool moved;

    public GameObject vase;
    public GameObject key;

    public Sprite brokenvase;

    public GameObject fish;

    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
       audiosource = GetComponent<AudioSource>();
       key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(fish!= null)
        {
            if (fish.GetComponent<InteractScript>().interacted)
            {
                move = true;
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == ("Player")&& move&&!moved)
        {
            transform.position = movecat.transform.position;
            moved = true;
            key.SetActive(true);
            vase.GetComponent<SpriteRenderer>().sprite = brokenvase;
            audiosource.PlayOneShot(audiosource.clip);
        }
    }
}
