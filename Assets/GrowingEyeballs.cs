using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingEyeballs : MonoBehaviour
{
    public List<GameObject> Eyeballs = new List<GameObject>();
    public GameObject GM;
    private Finalgame_GM GameMaster;

    public Sprite firstPhase;
    public Sprite secondPhase;
    public Sprite thirdPhase;

    private Sprite currentPhase;

    private int Phase = 0;

    public bool Activate = true;

    public GameObject on;
    public GameObject off;

    private void Start()
    {
        on.SetActive(false);
        off.SetActive(false);
        foreach (Transform child in transform)
        {
            Eyeballs.Add(child.gameObject);
            child.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }

        GameMaster = GM.GetComponent<Finalgame_GM>();
    }

    private void Update()
    {
        if (Activate)
        {
            on.SetActive(true);
            off.SetActive(false);
            if (GameMaster.a || GameMaster.b || GameMaster.c)
            {
                if (Phase == 0)
                {
                    Phase = 1;
                    currentPhase = firstPhase;
                }
                else
                {
                    if (GameMaster.a && GameMaster.b || GameMaster.c && GameMaster.a || GameMaster.b && GameMaster.c)
                    {
                        if (Phase == 1)
                        {
                            Phase = 2;
                            currentPhase = secondPhase;
                        }
                        else
                        {
                            if (GameMaster.a && GameMaster.b && GameMaster.c)
                            {
                                Phase = 3;
                                currentPhase = thirdPhase;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < Eyeballs.Count; i++)
            {
                if (currentPhase != null) Eyeballs[i].GetComponent<SpriteRenderer>().sprite = currentPhase;
            }
        }
        else
        {

            on.SetActive(false);
            off.SetActive(true);
        }
    }

    public void NoEyes()
    {
        if (Activate)
        {
            for (int i = 0; i < Eyeballs.Count; i++)
            {
                Eyeballs[i].SetActive(false);
            }
            Activate = false;
        }
        else
        {
            for (int i = 0; i < Eyeballs.Count; i++)
            {
                Eyeballs[i].SetActive(true);
            }
            Activate = true;
        }
        
    }

    public void ShowEyes()
    {
        for (int i = 0; i < Eyeballs.Count; i++)
        {
            Eyeballs[i].SetActive(false);
        }
        Activate = false;
    }
}
