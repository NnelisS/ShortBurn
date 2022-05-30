using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerInputStruct
{
    public float VerticalInput;
    public float HorizontalInput;

    public float RotationValue;

    public bool ButtonPressed;

    public PlayerInputStruct(float _horizontalValue, float _verticalValue, float _rotationValue, bool _buttonvalue)
    {
        VerticalInput = _verticalValue;
        HorizontalInput = _horizontalValue;
        RotationValue = _rotationValue;
        ButtonPressed = _buttonvalue;
    }
}