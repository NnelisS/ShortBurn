using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Scriptable Objects/Dialogue/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public Color NormalColor;

    public float Delay;
    public float TimeTillRemove;

    public Dialogue[] Dialogues;
}

[Serializable]
public class Dialogue 
{
    [TextArea(2, 4)]
    public string Text;

    public bool OverrideDefault = false;

    public bool UsePortrait = false;

    public Sprite portrait;
}

[CustomEditor(typeof(Dialogue))]
public class MyScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Dialogue dialogue = (Dialogue)target;
    }
}