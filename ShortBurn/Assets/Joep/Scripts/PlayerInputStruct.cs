using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerInputStruct
{
    public float VerticalInput;
    public float HorizontalInput;

    public bool ButtonPressed;

    public PlayerInputStruct(float _horizontalValue, float _verticalValue, bool _buttonvalue)
    {
        VerticalInput = _verticalValue;
        HorizontalInput = _horizontalValue;
        ButtonPressed = _buttonvalue;
    }
}