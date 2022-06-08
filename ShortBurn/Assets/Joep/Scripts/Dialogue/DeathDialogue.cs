using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DeathDialogue : MonoBehaviour
{
    public DialogueSO DeathMessages;

    private string currDialogue;

    public TextMeshProUGUI dialogueText;

    private string oldString;

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.T))
            PlayRandomDialogue();*/
    }

    public void PlayRandomDialogue()
    {
        currDialogue = "";
        dialogueText.text = currDialogue;

        StartCoroutine(TypeText(UnityEngine.Random.Range(0, DeathMessages.Dialogues.Length)));
    }

    private IEnumerator TypeText(int _messageCount = 0)
    {
        bool _isDone = false;

        if (currDialogue != "")
        {
            for (int i = oldString.Length + 3; i < DeathMessages.Dialogues[_messageCount].Length; i++)
            {
                currDialogue += DeathMessages.Dialogues[_messageCount].Substring(i, 1);
                dialogueText.text = currDialogue;
                yield return new WaitForSeconds(DeathMessages.Delay);
            }

            yield return new WaitForSeconds(1f);

            StartCoroutine(RemoveText(_messageCount));
        }
        else
        {
            for (int i = 0; i < DeathMessages.Dialogues[_messageCount].Length + 1; i++)
            {
                if (i != DeathMessages.Dialogues[_messageCount].Length)
                {
                    string _currChar = DeathMessages.Dialogues[_messageCount].Substring(i, 1);

                    if (CheckCharacter(_currChar))
                    {
                        oldString = currDialogue;

                        string _removeAmount = DeathMessages.Dialogues[_messageCount].Substring(i + 1, 1);

                        StartCoroutine(RemoveText(_messageCount, Int32.Parse(_removeAmount.ToString())));

                        i = DeathMessages.Dialogues[_messageCount].Length + 1;
                        _isDone = true;
                    }
                }

                if (!_isDone)
                {
                    currDialogue = DeathMessages.Dialogues[_messageCount].Substring(0, i);
                    dialogueText.text = currDialogue;
                    yield return new WaitForSeconds(DeathMessages.Delay);
                }
            }

            if (!_isDone)
            {
                yield return new WaitForSeconds(1f);

                StartCoroutine(RemoveText(_messageCount));
            }
        }
    }

    private IEnumerator RemoveText(int _messageCount, int _removeCount = 0)
    {
        if (_removeCount == 0)
            _removeCount = DeathMessages.Dialogues[_messageCount].Length;

        for (int i = 0; i < _removeCount; i++)
        {
            if (currDialogue.Length > 0)
                currDialogue = DeathMessages.Dialogues[_messageCount].Remove(currDialogue.Length - 1);

            dialogueText.text = currDialogue;
            yield return new WaitForSeconds(DeathMessages.Delay / 2);
        }

        if (_removeCount != DeathMessages.Dialogues[_messageCount].Length)
            StartCoroutine(TypeText(_messageCount));

        yield return new WaitForSeconds(DeathMessages.Delay);
    }

    private bool CheckCharacter(string _character)
    {
        string _checker = "-";

        if (_checker == _character)
            return true;

        return false;
    }
}
