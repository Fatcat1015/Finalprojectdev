using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    //public string dialogue_text;
    public TMP_Text dialogueText;

    private void Start()
    {
        dialogueUI.SetActive(false);
        dialogueText = GetComponent<TMP_Text>();
    }

    private void Update()
    {

    }
}
