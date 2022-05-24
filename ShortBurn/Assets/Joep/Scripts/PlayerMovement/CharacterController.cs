using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Mover
{
    //Character Stats
    public bool Jump;

    public bool IsClone;

    [Header("Private")]
    private float horizontalValue;
    private float verticalValue;
    private Quaternion rotationValue;
    private bool buttonValue;

    /// <summary>
    /// Use the character controller to move the player by getting the rotation and motion
    /// </summary>
    public void Move()
    {
        Vector3 _motion = transform.right * horizontalValue + transform.forward * verticalValue;
        
        Quaternion _rotation = rotationValue;

        if (buttonValue == true)
        {
            Debug.Log("The button press has been received");
        }

        //Character rotation
        if (IsClone)
            _CharCont.gameObject.transform.rotation = _rotation;
        //Character Movement
        _CharCont.Move(_motion * PlayerMovement.MoveSpeed);
    }

    /// <summary>
    /// Set the horizontal and vertical values 
    /// </summary>
    public void GivenInputs(PlayerInputStruct _inputs)
    {
        horizontalValue = _inputs.HorizontalInput;
        verticalValue = _inputs.VerticalInput;
        rotationValue = _inputs.RotationValue;
        buttonValue = _inputs.ButtonPressed;
    }

    /// <summary>
    /// put the horizontal and vertical values on 0
    /// </summary>
    public void ResetInputs()
    {
        horizontalValue = 0;
        verticalValue = 0;
    }

    /// <summary>
    /// Reset input and enable charactercontroller
    /// </summary>
    public void Reset()
    {
        ResetInputs();
        _CharCont.enabled = true;
    }
}
