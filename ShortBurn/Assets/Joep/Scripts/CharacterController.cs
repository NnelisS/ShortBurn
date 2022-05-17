using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Character Stats
    public float MoveSpeed = .05f;
    public bool Jump;

    public bool IsClone;

    [Header("Private")]
    private UnityEngine.CharacterController charCont;

    private float horizontalValue;
    private float verticalValue;
    private float horizontalRotationValue;
    private float verticalRotationValue;
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
        Vector3 _motion = transform.right * horizontalValue + transform.forward * verticalValue;
        //new Vector3(transform.right * horizontalValue, -2, verticalValue);
        Quaternion _rotation = Quaternion.Euler(verticalRotationValue, horizontalRotationValue, 0);
        //Vector3 _rotation = new Vector3(horizontalValue, 0, verticalValue);

        if (buttonValue == true)
        {
            Debug.Log("The button press has been received, do additional functionality here");
        }

        /*if (_rotation.magnitude > 0.1f)
        {
            float _targetAngle = Mathf.Atan2(_motion.x, _motion.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, _targetAngle, 0f);
        }*/
        //Actual Character Movement

        if (IsClone)
            charCont.gameObject.transform.rotation = _rotation;
        charCont.Move(_motion * MoveSpeed);
    }

    /// <summary>
    /// Set the horizontal and vertical values 
    /// </summary>
    public void GivenInputs(PlayerInputStruct _inputs)
    {
        horizontalValue = _inputs.HorizontalInput;
        verticalValue = _inputs.VerticalInput;
        horizontalRotationValue = _inputs.HorizontalRotation;
        verticalRotationValue = _inputs.VerticalRotation;
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
