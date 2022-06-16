using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Scriptable Objects/Dialogue/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public Color NormalColor;

    public float Delay;
    public float TimeTillRemove;

    [TextArea(2, 4)]
    public string[] Text;
}