using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private string input;
        private TextMeshProUGUI textHolder;

        private void Awake()
        {
            textHolder = GetComponent<TextMeshProUGUI>();
        }
    }
}

