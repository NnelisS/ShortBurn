using UnityEngine;

public struct PlayerInputStruct
{
    public Vector3 positionDelta;
    public float RotationDelta;
    public bool TriggerJump;

    public float DeltaTime;

    public PlayerInputStruct(Vector3 _positionDelta, float _rotationDelta, bool _triggerJump, float _deltaTime)
    {
        positionDelta = _positionDelta;
        RotationDelta = _rotationDelta;
        TriggerJump = _triggerJump;
        DeltaTime = _deltaTime;
    }
}