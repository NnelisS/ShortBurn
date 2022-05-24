using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : Mover
{
    private Vector3 velocity;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    protected override void GroundChecker()
    {
        base.GroundChecker();

        _IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (_IsGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }

        //Apply gravity
        velocity.y += PlayerMovement.Gravity * Time.deltaTime;
        _CharCont.Move(velocity * Time.deltaTime);
    }
}
