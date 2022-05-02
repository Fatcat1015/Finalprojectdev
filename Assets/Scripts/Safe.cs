using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public List<ClickPlusOne> safe_num = new List<ClickPlusOne>();
    public List<int> code = new List<int>();

    public GameObject poison;
    void Start()
    {
        foreach (Transform child in transform)
        {
            safe_num.Add(child.gameObject.GetComponent<ClickPlusOne>());
        }
        poison.SetActive(false);
    }

    void Update()
    {
        if (code_correct()&&poison != null)
        {
            poison.SetActive(true);
        }
    }

    bool code_correct()
    {
        for(int i = 0; i < safe_num.Count; i++)
        {
            if (safe_num[i].number != code[i]) return false;
        }

        return true;
    }
}
