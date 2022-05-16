using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    //This class should include all the potential inpuits that the player makes
    //These two are the movement inputs in both horizontal and vertical movement
    private float horizontalValue;
    private float verticalValue;
    private bool keyPressed;

    public void ListenForKeyPresses()
    {
        if (Input.GetKeyDown("space"))
        {
            keyPressed = true;
        }
    }

    public void GetInputs()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
    }

    public PlayerInputStruct GetInputStruct()
    {
        PlayerInputStruct playerInputs = new PlayerInputStruct(horizontalValue, verticalValue, keyPressed);
        return playerInputs;
    }

    public void ResetInput()
    {
        horizontalValue = 0;
        verticalValue = 0;
        keyPressed = false;
    }
}