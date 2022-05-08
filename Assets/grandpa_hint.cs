using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grandpa_hint : MonoBehaviour
{
    public GameObject gin;
    public GameObject ice;
    public GameObject poison;

    private TextMeshPro hint;

    [SerializeField] public List<string> dialogue = new List<string>();


    private void Start()
    {
        hint = GetComponent<TextMeshPro>();
    }
    // Update is called once per frame
    void Update()
    {
        if(gin == null)
        {
            hint.text = dialogue[1];
            gin = null;
            if(ice == null)
            {
                ice = null;
                hint.text = dialogue[2];
                if (poison.GetComponent<InteractScript>().interacted)
                {
                    hint.text = dialogue[3];
                }
            }
        }
        else
        {
            hint.text = dialogue[0];
        }
    }
}
