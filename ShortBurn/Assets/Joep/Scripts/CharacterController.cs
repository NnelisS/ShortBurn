using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Character Stats
    public float MoveSpeed = .05f;
    public bool Jump;

    [Header("Private")]
    private UnityEngine.CharacterController charCont;

    private float horizontalValue;
    private float verticalValue;
    private bool buttonValue;

    void Start()
    {
        charCont = GetComponent<UnityEngine.CharacterController>();
    }

    /// <summary>
    /// Use the character controller to move the player by getting the rotation and motion
    /// </summary>
    public void Move()
    {
        Vector3 _motion = new Vector3(horizontalValue, -2, verticalValue);
        Vector3 _rotation = new Vector3(horizontalValue, 0, verticalValue);

        if (buttonValue == true)
        {
            Debug.Log("The button press has been received, do additional functionality here");
        }

        if (_rotation.magnitude > 0.1f)
        {
            float _targetAngle = Mathf.Atan2(_motion.x, _motion.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, _targetAngle, 0f);
        }
        //Actual Character Movement
        charCont.Move(_motion * MoveSpeed);
    }

    /// <summary>
    /// Set the horizontal and vertical values 
    /// </summary>
    public void GivenInputs(PlayerInputStruct _inputs)
    {
        horizontalValue = _inputs.HorizontalInput;
        verticalValue = _inputs.VerticalInput;
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
        charCont.enabled = true;
    }
}
