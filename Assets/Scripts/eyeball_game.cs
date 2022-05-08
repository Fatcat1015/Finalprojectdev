using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeball_game : MonoBehaviour
{
    public List<GameObject> eyeball = new List<GameObject>();
    public Sprite finished_cake;
    public GameObject cake_slice;

    public bool won;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in gameObject.transform)
        {
            eyeball.Add(child.gameObject);
        }

        cake_slice = GameObject.Find("cake slice");
        cake_slice.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (game_finished() == false)
        {
            for (int i = 0; i < eyeball.Count; i++)
            {
                if (eyeball[i].GetComponent<eyeball>().clicked)
                {
                    eyeball[i].GetComponent<eyeball>().on = eyeball[i].GetComponent<eyeball>().on ? false : true;
                    if (i - 1 >= 0)
                    {
                        eyeball[i - 1].GetComponent<eyeball>().on = eyeball[i - 1].GetComponent<eyeball>().on ? false : true;
                    }
                    else
                    {
                        eyeball[eyeball.Count - 1].GetComponent<eyeball>().on = eyeball[eyeball.Count - 1].GetComponent<eyeball>().on ? false : true;
                    }

                    if (i + 1 <= eyeball.Count - 1)
                    {
                        eyeball[i + 1].GetComponent<eyeball>().on = eyeball[i + 1].GetComponent<eyeball>().on ? false : true;
                    }
                    else
                    {
                        eyeball[0].GetComponent<eyeball>().on = eyeball[0].GetComponent<eyeball>().on ? false : true;
                    }
                    eyeball[i].GetComponent<eyeball>().clicked = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < eyeball.Count; i++)
            {
                eyeball[i].SetActive(false);
            }
                GetComponent<SpriteRenderer>().sprite = finished_cake;
            if(cake_slice!=null)cake_slice.SetActive(true);
            won = true;
        }
    }

    private bool game_finished()
    {
        for (int i = 0; i < eyeball.Count; i++)
        {
            if (eyeball[i].GetComponent<eyeball>().on == false)
            {
                return false;
            }
        }
        return true;
    }
}
