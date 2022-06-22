using System.Collections;
using UnityEngine;
using TMPro;

namespace DialogueSystem 
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool IsFinished { get; protected set; }

        protected IEnumerator WriteText(string _input, TextMeshProUGUI _textHolder, Color _textColor, TMP_FontAsset _font, float _delay, AudioClip _sound, float _delayBetweenLines)
        {
            _textHolder.font = _font;
            _textHolder.color = _textColor;

            for (int i = 0; i < _input.Length; i++)
            {
                _textHolder.text += _input[i];
                SoundManager.instance.PlaySound(_sound);
                yield return new WaitForSeconds(_delay);
            }

            //yield return new WaitForSeconds(_delayBetweenLines);
            yield return new WaitUntil(() => Input.GetMouseButton(0));

            IsFinished = true;
        }
    }
}