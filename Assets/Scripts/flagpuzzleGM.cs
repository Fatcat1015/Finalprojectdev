using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagpuzzleGM : MonoBehaviour
{
    public List<GameObject> Flags = new List<GameObject>();
    public List<Vector3> FlagPos = new List<Vector3>();
    [SerializeField] private List<int> shuffle_order = new List<int>();

    public bool playing;
    public GameObject prize;
    public GameObject destroy;

    private void Start()
    {
        prize.SetActive(false);
        foreach (Transform child in gameObject.transform)
        {
            Flags.Add(child.gameObject);
        }

        foreach (Transform child in gameObject.transform)
        {
            FlagPos.Add(child.transform.position);
        }

        for(int i = 0; i < Flags.Count; i++)
        {
            Flags[i].transform.position = FlagPos[shuffle_order[i]];
            Flags[i].GetComponent<FlagPiece>().index = shuffle_order[i];
        }
    }

    private void Update()
    {
        if (winning())
        {
            for (int i = 0; i < Flags.Count; i++)
            {
                if(Flags[i] != null)Flags[i].GetComponent<FlagPiece>().finished = true;
            }
            if(destroy!= null) Destroy(destroy);
            if(prize!= null) prize.SetActive(true);
        }
        
    }

    public void PutdownFlag(GameObject flag)
    {
        float closest_pos = 100;
        int pos = 0;
        for (int i = 0; i < Flags.Count; i++)
        {
            if (Vector3.Distance(FlagPos[i], flag.transform.position) < closest_pos)
            {
                closest_pos = Vector3.Distance(FlagPos[i], flag.transform.position);
                pos = i;
            }
        }
        flag.transform.position = FlagPos[pos];
        for (int i = 0; i < Flags.Count; i++)//switch place with other flag;
        {
            if (Flags[i].GetComponent<FlagPiece>().index == pos)
            {
                Flags[i].transform.position = FlagPos[flag.GetComponent<FlagPiece>().index];
                Flags[i].GetComponent<FlagPiece>().index = flag.GetComponent<FlagPiece>().index;
            }
        }

        flag.GetComponent<FlagPiece>().index = pos;

        }

    private bool winning()
    {
        if(prize != null)
        {
            for (int i = 0; i < Flags.Count; i++)
            {
                if (Flags[i].transform.position != FlagPos[i]) return false;
            }
        }
        
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            playing = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playing = false;
        }
    }
}
