using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    //This class should include all the potential inputs that the player makes
    //These two are the movement inputs in both horizontal and vertical movement
    private float horizontalValue;
    private float verticalValue;
    private bool keyPressed;

    /// <summary>
    /// Turns bool on if jump key pressed
    /// </summary>
    public void ListenForKeyPresses()
    {
        if (Input.GetKeyDown("space"))
        {
            keyPressed = true;
        }
    }

    /// <summary>
    /// Get the horizontal and vertical input
    /// </summary>
    public void GetInputs()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Get PlayerInputStruct with corrisponding input
    /// </summary>
    public PlayerInputStruct GetInputStruct()
    {
        PlayerInputStruct _playerInputs = new PlayerInputStruct(horizontalValue, verticalValue, keyPressed);
        return _playerInputs;
    }

    /// <summary>
    /// Put all the values to 0 and booleans to false
    /// </summary>
    public void ResetInput()
    {
        horizontalValue = 0;
        verticalValue = 0;
        keyPressed = false;
    }
}