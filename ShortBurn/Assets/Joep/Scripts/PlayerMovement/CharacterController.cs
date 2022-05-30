using UnityEngine;

public class CharacterController : Mover
{
    //Character Stats
    public bool Jump;

    public bool IsClone;

    [Header("Private")]
    private float horizontalValue;
    private float verticalValue;
    private float rotationValue;
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
            startYRotation = Player.transform.rotation.eulerAngles.y;

        rotation = Quaternion.Euler(transform.rotation.x, rotationValue, transform.rotation.z);

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

    private float CalculateYRotation()
    {
        float _dir = rotationValue - startYRotation;

        float _newRot = _dir - startYRotation;

        //Does not work ^

        return rotationValue;
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
