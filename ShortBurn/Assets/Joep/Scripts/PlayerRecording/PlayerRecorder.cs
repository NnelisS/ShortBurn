using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    //This class should include all the potential inputs that the player makes

    private float horizontalValue;
    private float verticalValue;

    private float rotationValue;

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
        //TODO: delta opslaan

        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");

        rotationValue = transform.rotation.eulerAngles.y;
    }

    /// <summary>
    /// Get PlayerInputStruct with corrisponding input
    /// </summary>
    public PlayerInputStruct GetInputStruct()
    {
        PlayerInputStruct _playerInputs = new PlayerInputStruct(horizontalValue, verticalValue, rotationValue, keyPressed);
        return _playerInputs;
    }

    /// <summary>
    /// Put all the values to 0 and booleans to false
    /// </summary>
    public void ResetInput()
    {
        horizontalValue = 0;
        verticalValue = 0;
        rotationValue = 0;
        keyPressed = false;
    }
}