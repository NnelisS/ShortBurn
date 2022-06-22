using System.Collections;
using UnityEngine;
using TMPro;

namespace DialogueSystem 
{
    public class DialogueBaseClass : MonoBehaviour
    {
        protected IEnumerator WriteText(string _input, TextMeshProUGUI _textHolder, Color _textColor, TMP_FontAsset _font, float _delay, AudioClip _sound)
        {
            _textHolder.font = _font;
            _textHolder.color = _textColor;

            for (int i = 0; i < _input.Length; i++)
            {
                _textHolder.text += _input[i];
                SoundManager.instance.PlaySound(_sound);
                yield return new WaitForSeconds(_delay);
            }
        }
    }
}