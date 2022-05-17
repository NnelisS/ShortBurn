using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerInputStruct
{
    public float VerticalInput;
    public float HorizontalInput;

    public float VerticalRotation;
    public float HorizontalRotation;

    public bool ButtonPressed;

    public PlayerInputStruct(float _horizontalValue, float _verticalValue, float _horizontalRotation, float _verticalRotation, bool _buttonvalue)
    {
        VerticalInput = _verticalValue;
        HorizontalInput = _horizontalValue;
        HorizontalRotation = _horizontalRotation;
        VerticalRotation = _verticalRotation;
        ButtonPressed = _buttonvalue;
    }
}