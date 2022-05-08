using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text_recordplayer : MonoBehaviour
{
    public GameObject needle;
    public GameObject record;

    private TextMeshPro hint;

    [SerializeField] public List<string> dialogue = new List<string>();


    private void Start()
    {
        hint = GetComponent<TextMeshPro>();
    }
    // Update is called once per frame
    void Update()
    {

        if (needle == null)
        {
            hint.text = dialogue[1];
            if (record.GetComponent<InteractScript>().interacted)
            {
                hint.text = dialogue[3];
            }
        }
        else
            if (record.GetComponent<InteractScript>().interacted)
            {
            hint.text = dialogue[2];
            }
        else
        {
            hint.text = dialogue[0];
        }
    }
}
