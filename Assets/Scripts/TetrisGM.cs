using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGM : MonoBehaviour
{
    public bool playing;
    public GameObject cube;
    public GameObject cube_prefab;
    public Transform spawnpoint;

    public List<GameObject> fallencubes = new List<GameObject>();

    public int clear_count = 0;
    public GameObject prize;

    public bool won;

    private void Start()
    {
        prize.SetActive(false);
    }
    private void Update()
    {
        if(clear_count < 3)
        {
            GameObject.Find("poster3 (1)").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poster" + (3-clear_count));
        }

        if(clear_count >= 3&&prize!= null)
        {
            playing = false;
            won = true;
            prize.SetActive(true);
        }

        if (playing)    //detect if in the game or not
        {
            //start dispensing cubes
            if(cube == null)
            {
                int cubecolor = Random.Range(1, 4);//randomnize color
                cube = Instantiate(cube_prefab, spawnpoint.position, Quaternion.identity) as GameObject;
                cube.GetComponent<PosterTetris>().color = cubecolor;
                cube.transform.SetParent(spawnpoint.transform);
            }
            
            if (cube.GetComponent<PosterTetris>().falling == false)
            {
                fallencubes.Add(cube);
                cube = null;
            }
        }
        else
        {
            for(int i = 0; i < fallencubes.Count; i++)
            {
                Destroy(fallencubes[i]);
                fallencubes.Remove(fallencubes[i]);
            }
            if(clear_count<3) clear_count = 0;

            Destroy(cube);
            //reset status
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (clear_count < 3)
        {
            if (collision.tag == "Player")
            {
                playing = true;
            }
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
