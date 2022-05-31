using UnityEngine;

public struct PlayerInputStruct
{
    public Vector3 positionDelta;
    public float RotationDelta;
    public bool TriggerJump;

    public float TimeStamp;

    public PlayerInputStruct(Vector3 _positionDelta, float _rotationDelta, bool _triggerJump, float _timeStamp)
    {
        positionDelta = _positionDelta;
        RotationDelta = _rotationDelta;
        TriggerJump = _triggerJump;
        TimeStamp = _timeStamp;
    }
}