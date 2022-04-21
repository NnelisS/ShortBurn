using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool jump;
    private Vector3 initialPosition;
    private Vector3 initialRotation;
    private float horizontalValue;
    private float verticalValue;
    private bool buttonValue;
    private GameObject characterGameObject;

    //Character Stats
    public float moveSpeed = .05f;

    private UnityEngine.CharacterController charCont;

    void Start()
    {
        characterGameObject = gameObject;
        initialPosition = GetComponent<Transform>().position;
        initialRotation = GetComponent<Transform>().rotation.eulerAngles;
        charCont = GetComponent<UnityEngine.CharacterController>();
    }

    public void Move()
    {
        Vector3 motion = new Vector3(horizontalValue, -2, verticalValue);
        Vector3 rotation = new Vector3(horizontalValue, 0, verticalValue);

        if (buttonValue == true)
        {
            Debug.Log("The button press has been received, do additional functionality here");
        }

        if (rotation.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(motion.x, motion.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }
        //Actual Character Movement
        charCont.Move(motion * moveSpeed);
    }

    public void GivenInputs(PlayerInputStruct inputs)
    {
        horizontalValue = inputs.horizontalInput;
        verticalValue = inputs.verticalInput;
        buttonValue = inputs.buttonPressed;
    }

    public void ResetInputs()
    {
        horizontalValue = 0;
        verticalValue = 0;
    }

    public void Reset()
    {
        ResetInputs();
        charCont.enabled = false;
        /*charCont.transform.position = initialPosition;
        charCont.transform.eulerAngles = initialRotation;*/
        charCont.enabled = true;
    }
}
