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
    [HideInInspector] public GameObject Player;
    [HideInInspector] public float startYRotation = 999;
    private Quaternion rotation;

    /// <summary>
    /// Use the character controller to move the player by getting the rotation and motion
    /// </summary>
    public void Move()
    {
        if (IsClone && GetComponent<MeshRenderer>().enabled == false)
            GetComponent<MeshRenderer>().enabled = true;

        Vector3 _motion = transform.right * horizontalValue + transform.forward * verticalValue;

        if (startYRotation == 999 && IsClone)
            startYRotation = CalculateStartYRotation(Player.transform.rotation.eulerAngles.y);

        rotation = rotationValue;

        if (buttonValue == true)
        {
            Debug.Log("The button press has been received");
        }

        //Character rotation
        if (IsClone)
        {
            //Debug.Log(startYRotation + " : " + CalculateYRotation());

            _charCont.gameObject.transform.rotation = Quaternion.Euler(rotation.x, CalculateYRotation(), rotation.z);
        }

        //Character Movement
        _charCont.Move(_motion * PlayerMovement.MoveSpeed);
    }

    private float CalculateStartYRotation(float value)
    {
        print(value);

        float _f = Mathf.Abs(rotationValue.y - Mathf.Clamp(value, 0, 360));

        return _f;
    }

    private float CalculateYRotation()
    {
        float _rot = rotationValue.eulerAngles.y;

        return _rot + startYRotation;
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
        _charCont.enabled = true;
    }
}
