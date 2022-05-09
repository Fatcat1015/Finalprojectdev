using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dad_hint : MonoBehaviour
{
    public GameObject knife;
    public GameObject dadTrigger;
    private TextMeshPro hint;

    [SerializeField] public List<string> dialogue = new List<string>();


    private void Start()
    {
        hint = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if (dadTrigger.GetComponent<InteractScript>().interacted)
        {
            hint.text = dialogue[1];
        }
        if (knife.GetComponent<InteractScript>().interacted)
        {
            hint.text = dialogue[2];
        }
        else
        {
            hint.text = dialogue[0];
        }
    }
}
