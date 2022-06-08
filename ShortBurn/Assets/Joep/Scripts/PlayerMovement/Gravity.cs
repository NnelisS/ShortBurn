using UnityEngine;

public class Gravity : Mover
{
    private Vector3 velocity;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    public LayerMask GroundMaskCube;

    public bool DisableJump = false;


    /// <summary>
    /// Apply gravity if the player isnt grounded
    /// </summary>
    protected override void GroundChecker()
    {
        base.GroundChecker();

        _IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        _IsGroundedOnCube = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMaskCube);

        if (_IsGrounded && velocity.y < 0 || _IsGroundedOnCube && velocity.y < 0)
            velocity.y = -0.5f;

        //Apply gravity
        velocity.y += PlayerMovement.Gravity * Time.deltaTime;

        _charCont.Move(velocity * Time.deltaTime);
    }

    public void TriggerJump()
    {
        if (_IsGrounded && DisableJump == false || _IsGroundedOnCube && DisableJump == false)
            Jump();
    }

    protected override void Jump()
    {
        base.Jump();

        velocity.y += PlayerMovement.Gravity * Time.deltaTime;

        _charCont.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _IsGrounded || Input.GetButtonDown("Jump") && _IsGroundedOnCube)
            velocity.y = Mathf.Sqrt(PlayerMovement.JumpHeight * -2f * PlayerMovement.Gravity);
    }
}
