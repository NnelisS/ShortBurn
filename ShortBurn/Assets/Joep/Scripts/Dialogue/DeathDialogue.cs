using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathDialogue : MonoBehaviour
{
    public DialogueSO DeathMessages;

    private string currDialogue;

    public TextMeshProUGUI dialogueText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            PlayRandomDialogue();
    }

    public void PlayRandomDialogue()
    {
        StartCoroutine(TypeText(Random.Range(0, DeathMessages.Dialogues.Length)));
    }

    private IEnumerator TypeText(int _messageCount)
    {
        for (int i = 0; i < DeathMessages.Dialogues[_messageCount].Length + 1; i++)
        {
            currDialogue = DeathMessages.Dialogues[_messageCount].Substring(0, i);
            dialogueText.text = currDialogue;
            yield return new WaitForSeconds(DeathMessages.Delay);
        }

        yield return new WaitForSeconds(1f);
    }
}