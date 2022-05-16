using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerInputStruct
{
    public float verticalInput;
    public float horizontalInput;

    public bool buttonPressed;

    public PlayerInputStruct(float horizontalValue, float verticalValue, bool buttonvalue)
    {
        verticalInput = verticalValue;
        horizontalInput = horizontalValue;
        buttonPressed = buttonvalue;
    }
}