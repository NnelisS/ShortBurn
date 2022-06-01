using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Scriptable Objects/Dialogue/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public float Delay;

    [TextArea(2,4)]
    public string[] Dialogues;
}
