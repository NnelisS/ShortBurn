using System.Collections;
using UnityEngine;
using TMPro;

namespace DialogueSystem 
{
    public class DialogueBaseClass : MonoBehaviour
    {
        private IEnumerator WriteText(string _input, TextMeshProUGUI _textHolder)
        {
            for (int i = 0; i < _input.Length; i++)
            {
                _textHolder.text += _input[i];
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}