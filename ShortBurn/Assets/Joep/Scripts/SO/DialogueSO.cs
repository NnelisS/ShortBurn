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
public class Dialogue
{
    [TextArea(2, 4)]
    public string Text;

    public bool OvverideDefault = false;
}

[CustomEditor(typeof(Dialogue))]
public class MyScriptEditor : Editor
{
    override public void OnInspectorGUI()
    {
        var _target = target as DialogueSO;

        /*_target.someBool = GUILayout.Toggle(_target.someBool, "Some Bool");
        
        if (_target.someBool)
        {
            _target.someFloat = EditorGUILayout.FloatField("Soem Float:", _target.someFloat);
        }*/
    }
}