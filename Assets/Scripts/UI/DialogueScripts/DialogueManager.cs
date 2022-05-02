using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public string dialogue_text;
    private TMP_Text TMPtext;

    private void Start()
    {
        dialogueUI.SetActive(false);
        TMPtext = GetComponent<TMP_Text>();
    }

    private void Update()
    {

    }
}
