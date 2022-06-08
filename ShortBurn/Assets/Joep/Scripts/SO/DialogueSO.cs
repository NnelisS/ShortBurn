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

[System.Serializable]
public class Dialogue : PropertyAttribute
{
    [TextArea(2, 4)]
    public string Text;

    public bool OverrideDefault = false;
}

[CustomPropertyDrawer(typeof(Dialogue))]
public class MyScriptEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Dialogue dialogue = (Dialogue)attribute;
        EditorGUI.PropertyField(position, property, label, true);
    }
}