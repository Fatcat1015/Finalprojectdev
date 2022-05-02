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

    public AudioClip danceMusic;
    public AudioClip bgm;

    AudioSource as_bgm;

    GameObject mom;
    // Start is called before the first frame update
    void Start()
    {
        notes = GameObject.Find("Notes");
        notes.SetActive(false);

        Record = GameObject.Find("RecordSlot");
        Needle = GameObject.Find("Playing Needle");
        as_bgm = GameObject.Find("sounds").GetComponent<AudioSource>();
        mom = GameObject.Find("Mom_figure");
    }

    // Update is called once per frame
    void Update()
    {
        if (Record.GetComponent<InteractScript>().interacted && Needle.GetComponent<FurnitureInteractive>().open)
        {
            notes.SetActive(true);
            playing = true;
            mom.GetComponent<Animator>().enabled = true;
        }
        else
        {
            notes.SetActive(false);
            playing_ = true;
            mom.GetComponent<Animator>().enabled = false;
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
