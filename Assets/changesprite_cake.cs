using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changesprite_cake : MonoBehaviour
{
    public GameObject cakegame;
    public Sprite finished_cake;

    private void Update()
    {
        if (cakegame.GetComponent<eyeball_game>().won) GetComponent<SpriteRenderer>().sprite = finished_cake;
    }

}
