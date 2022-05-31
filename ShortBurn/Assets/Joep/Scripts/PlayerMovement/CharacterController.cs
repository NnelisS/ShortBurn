using UnityEngine;

public class CharacterController : Mover
{
    //Character Stats
    public bool Jump;

    public bool IsClone;

    [HideInInspector] public GameObject Player;

    /// <summary>
    /// Use the character controller to move the player by getting the rotation and motion
    /// </summary>
    public void Move(PlayerInputStruct _inputs)
    {
        if (IsClone && GetComponent<MeshRenderer>().enabled == false)
            GetComponent<MeshRenderer>().enabled = true;

        if (_inputs.TriggerJump)
        {
            Debug.Log("The Jump press has been received");
        }

        //Character rotation
        if (IsClone)
        {
            transform.rotation *= Quaternion.Euler(0, _inputs.RotationDelta, 0);

            Vector3 rotated = transform.rotation * _inputs.positionDelta;

            _charCont.Move(-rotated *
                PlayerMovement.MoveSpeed);

            return;
        }

        //Character Movement
        _charCont.Move(transform.rotation * _inputs.positionDelta * PlayerMovement.MoveSpeed);
    }

    /// <summary>
    /// Reset input and enable charactercontroller
    /// </summary>
    public void Reset()
    {
        _charCont.enabled = true;
    }
}
