using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mom_hint : MonoBehaviour
{
    public GameObject cake;
    public GameObject music;
    public GameObject rope;

    private TextMeshPro hint;

    [SerializeField] public List<string> dialogue = new List<string>();

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    private void Start()
    {
        hint = GetComponent<TextMeshPro>();
        rope.GetComponent<BoxCollider2D>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (cake == null)
        {
            hint.text = dialogue[1];
            gameObject.transform.position = pos1.position;
            if (music.GetComponent<RecordPlayer>().playing)
            {
                hint.text = dialogue[2];
                gameObject.transform.position = pos2.position;
                if(rope != null) rope.GetComponent<BoxCollider2D>().enabled = true;
                if (rope.GetComponent<InteractScript>().interacted)
                {
                    hint.text = dialogue[3];
                    gameObject.transform.position = pos3.position;
                }
            }
            else
            {
                if (rope != null) rope.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            hint.text = dialogue[0];
        }
    }
}
