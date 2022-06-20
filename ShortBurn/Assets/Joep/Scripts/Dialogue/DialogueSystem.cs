using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class DialogueSystem : MonoBehaviour
{
    public DialogueSO Messages;

    public TextMeshProUGUI dialogueText;

    [Header("Private")]
    private string currDialogue;
    private string oldString;

    private void Start()
    {
        dialogueText.color = Messages.NormalColor;
    }

    /// <summary>
    /// Chose one of the Dialogues in the list and type it
    /// </summary>
    public void PlayRandomDialogue()
    {
        //Reset dialogue
        currDialogue = "";
        dialogueText.text = currDialogue;

        StartCoroutine(TypeText(UnityEngine.Random.Range(0, Messages.Text.Length)));
    }

    /// <summary>
    /// Types the text and starts the RemoveText coroutine shortly after its done
    /// </summary>
    private IEnumerator TypeText(int _messageCount = 0)
    {
        bool _isDone = false;

        if (currDialogue != "") //If there already is dialogue
        {
            //Type the remaining text
            for (int i = oldString.Length + 3; i < Messages.Text[_messageCount].Length; i++)
            {
                if (!CheckCharacter(Messages.Text[_messageCount].Substring(i, 1), ""))
                    AudioManager.instance.Play("Type");
                currDialogue += Messages.Text[_messageCount].Substring(i, 1);
                dialogueText.text = currDialogue;
                yield return new WaitForSeconds(Messages.Delay);
            }

            yield return new WaitForSeconds(Messages.TimeTillRemove);

            //Remove the text
            StartCoroutine(RemoveText(_messageCount));
        }
        else
        {
            for (int i = 0; i < Messages.Text[_messageCount].Length + 1; i++)
            {
                if (i != Messages.Text[_messageCount].Length)
                {
                    string _currChar = Messages.Text[_messageCount].Substring(i, 1);

                    if (CheckCharacter(_currChar, "-")) //Check the current character
                    {
                        oldString = currDialogue;

                        string _removeAmount = Messages.Text[_messageCount].Substring(i + 1, 1);

                        StartCoroutine(RemoveText(_messageCount, Int32.Parse(_removeAmount.ToString())));

                        i = Messages.Text[_messageCount].Length + 1;
                        _isDone = true;
                    }
                }

                if (!_isDone)
                {
                    //Add the letter to the string and text
                    if (!CheckCharacter(Messages.Text[_messageCount].Substring(i, 1), ""))
                        AudioManager.instance.Play("Type");
                    currDialogue = Messages.Text[_messageCount].Substring(0, i);
                    dialogueText.text = currDialogue;
                    yield return new WaitForSeconds(Messages.Delay);
                }
            }

            if (!_isDone) //When all text is typed wait a second and start removing the text
            {
                yield return new WaitForSeconds(Messages.TimeTillRemove);

                StartCoroutine(RemoveText(_messageCount));
            }
        }
    }

    /// <summary>
    /// Removes the text and Start the type text again if the _removeCount isnt 0
    /// </summary>
    private IEnumerator RemoveText(int _messageCount, int _removeCount = 0)
    {
        if (_removeCount == 0)
            _removeCount = Messages.Text[_messageCount].Length;

        for (int i = 0; i < _removeCount; i++) //Remove the giving amount of letters
        {
            if (currDialogue.Length > 0)
                currDialogue = currDialogue.Remove(currDialogue.Length - 1);

            dialogueText.text = currDialogue;
            if (!CheckCharacter(Messages.Text[_messageCount].Substring(i, 1), ""))
                AudioManager.instance.Play("Type");
            yield return new WaitForSeconds(Messages.Delay / 2);
        }

        if (_removeCount != Messages.Text[_messageCount].Length) //Start typing if there is still text
            StartCoroutine(TypeText(_messageCount));

        yield return new WaitForSeconds(Messages.Delay);
    }

    /// <summary>
    /// Checks the given character and if its - return true
    /// </summary>
    private bool CheckCharacter(string _character, string _check)
    {
        if (_character == _check)
            return true;

        return false;
    }
}
