using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Mover
{
    //Character Stats
    public bool Jump;

    public bool IsClone;

    [HideInInspector] public GameObject Player;

    private Gravity gravity;

    private void Start()
    {
        gravity = GetComponent<Gravity>();
    }

    /// <summary>
    /// Use the character controller to move the player by getting the rotation and motion
    /// </summary>
    public void Move(PlayerInputStruct _inputs)
    {
        if (IsClone && GetComponent<MeshRenderer>().enabled == false)
        {
            GetComponent<MeshRenderer>().enabled = true;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        if (_inputs.TriggerJump)
        {
            gravity.TriggerJump();
            Debug.Log("The Jump press has been received");
        }

        //Character rotation
        if (IsClone)
        {
            //transform.position = Vector3.Lerp(_inputs.positionDelta, _inputs.positionDelta, .1f);

            transform.rotation *= Quaternion.Euler(0, Mathf.Lerp(_inputs.RotationDelta, _inputs.RotationDelta, _inputs.TimeStamp), 0);

            Vector3 rotated = transform.rotation * Vector3.Lerp(_inputs.positionDelta, _inputs.positionDelta, _inputs.TimeStamp);

            _charCont.Move(rotated * PlayerMovement.MoveSpeed);

            /*Vector3 rotated = transform.rotation * _inputs.positionDelta;

            _charCont.Move(-rotated * PlayerMovement.MoveSpeed);*/

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
