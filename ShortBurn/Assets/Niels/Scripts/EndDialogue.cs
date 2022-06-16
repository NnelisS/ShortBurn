using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogue : MonoBehaviour
{
    public DialogueSystem diaSys;

    void Start()
    {
        diaSys.PlayRandomDialogue();
    }

    private void Update()
    {
        diaSys.PlayRandomDialogue();
    }
}
