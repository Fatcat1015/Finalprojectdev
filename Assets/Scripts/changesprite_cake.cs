using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changesprite_cake : MonoBehaviour
{
    public GameObject cakegame;
    public Sprite finished_cake;

    public bool tetris;

    private void Update()
    {
        if (tetris)
        {
            if (cakegame.GetComponent<TetrisGM>().won) GetComponent<SpriteRenderer>().sprite = finished_cake;
        }
        else
        if (cakegame.GetComponent<eyeball_game>().won) GetComponent<SpriteRenderer>().sprite = finished_cake;
    }

}
