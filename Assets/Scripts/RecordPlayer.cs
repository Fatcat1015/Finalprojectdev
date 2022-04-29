using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    public bool playing;

    GameObject notes;
    GameObject Record;
    GameObject Needle;
    // Start is called before the first frame update
    void Start()
    {
        notes = GameObject.Find("Notes");
        notes.SetActive(false);

        Record = GameObject.Find("RecordSlot");
        Needle = GameObject.Find("Playing Needle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Record.GetComponent<InteractScript>().interacted && Needle.GetComponent<FurnitureInteractive>().open)
        {
            notes.SetActive(true);
            playing = true;
        }
        else
        {
            notes.SetActive(false);
            playing = false;

        }
    }
}
