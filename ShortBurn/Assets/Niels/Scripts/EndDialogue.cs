using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogue : MonoBehaviour
{
    public DialogueSystemOld diaSys;

    void Start()
    {
        diaSys.PlayRandomDialogue();
    }
}
