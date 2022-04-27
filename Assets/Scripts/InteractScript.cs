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

    public AudioSource myAudioSource;
    public AudioClip useItemSound;

    bool alreadyPlayed = false;

    [SerializeField] private int interval = 1;

    public string Activatedby;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = before;
        if (transform.childCount != 0)
        {
            //Debug.Log(transform.childCount);
            transform.GetChild(0).gameObject.SetActive(false);

            myAudioSource = GetComponent<AudioSource>();
        }

    }

    private void Update()
    {
        if (interacted)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = after;
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

    }

    private IEnumerator activate_once(int seconds)
    {

        yield return new WaitForSeconds(seconds);
        if (transform.childCount != 0)
        {
            GameObject child = transform.GetChild(0).gameObject;
            child.SetActive(true);
            child.transform.SetParent(null);
            Destroy(gameObject);
        }

        yield return null;
    }
}
