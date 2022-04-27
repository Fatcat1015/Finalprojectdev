using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Invent_item_name : MonoBehaviour
{
    public string item_text;
    private ClickMouse cm;
    private TMP_Text TMPtext;

    private void Start()
    {
        cm = GameObject.Find("Player").GetComponent<ClickMouse>();
        TMPtext = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        if (cm.item != null)
        {
            item_text = cm.item.name;
        }
        else
        {
            item_text = "Click item to show name";
        }

        TMPtext.text = item_text;
    }
}
