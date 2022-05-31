using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/Player/Player Movement")]
public class PlayerSO : ScriptableObject
{
    public float MoveSpeed = .05f;
    public float Gravity = -9.81f;
}
