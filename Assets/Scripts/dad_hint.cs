using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dad_hint : MonoBehaviour
{
    public GameObject knife;

    private TextMeshPro hint;

    [SerializeField] public List<string> dialogue = new List<string>();


    private void Start()
    {
        hint = GetComponent<TextMeshPro>();
    }
    // Update is called once per frame
    void Update()
    {
        if (knife.GetComponent<InteractScript>().interacted)
                {
                    hint.text = dialogue[1];
                }
        else
        {
            hint.text = dialogue[0];
        }
    }
}
