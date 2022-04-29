using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public string dialogue_text;
    private TMP_Text TMPtext;

    private void Start()
    {
        TMPtext = GetComponent<TMP_Text>();
    }

    private void Update()
    {

    }
}
