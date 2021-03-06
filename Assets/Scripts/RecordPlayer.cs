using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    public bool playing;
    public bool playing_;

    GameObject notes;
    GameObject Record;
    GameObject Needle;

    GameObject strangled;
    GameObject stamp;

    public AudioClip danceMusic;
    public AudioClip bgm;

    AudioSource as_bgm;

    GameObject mom;
    GameObject mom_dancing;
    // Start is called before the first frame update
    void Start()
    {
        notes = GameObject.Find("Notes");
        notes.SetActive(false);

        strangled = GameObject.Find("rope slot");

        stamp = GameObject.Find("Stamp3");
        stamp.SetActive(false);

        Record = GameObject.Find("RecordSlot");
        Needle = GameObject.Find("Playing Needle");
        as_bgm = GameObject.Find("sounds").GetComponent<AudioSource>();
        mom = GameObject.Find("Mom_figure");
        mom_dancing = GameObject.Find("Mom-dancing");

        mom_dancing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Record.GetComponent<InteractScript>().interacted && Needle.GetComponent<FurnitureInteractive>().open)//if music is playing
        {
            notes.SetActive(true);
            playing = true;
            if (stamp != null) stamp.SetActive(true);//stamp when mom dancing
            if (strangled.GetComponent<InteractScript>().interacted == false)
            {
                mom_dancing.SetActive(true);
                mom.GetComponent<SpriteRenderer>().enabled = false;
            }

        }
        else
        {
            notes.SetActive(false);
            playing_ = true;
            if (stamp != null) stamp.SetActive(false);
            if(strangled!= null)
            {
                if (strangled.GetComponent<InteractScript>().interacted == false)
                {
                    mom_dancing.SetActive(false);
                    mom.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
        if (strangled != null)
        {
            if (strangled.GetComponent<InteractScript>().interacted)
            {
                mom_dancing.SetActive(false);
                mom.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
            

        if (playing && as_bgm.clip == bgm)
        {
            as_bgm.Stop();
            as_bgm.clip = danceMusic;
            as_bgm.Play();
            playing = false;
        }
        if (playing_&& as_bgm.clip == danceMusic)
        {
            as_bgm.Stop();
            as_bgm.clip = bgm;
            as_bgm.Play();
            playing_ = false;
        }
    }
}
