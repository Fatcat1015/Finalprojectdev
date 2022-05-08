using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{

    public void Hover()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<ClickMouse>().hover(gameObject);
    }

    public void NotHover()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<ClickMouse>().hover(null);
    }
}
