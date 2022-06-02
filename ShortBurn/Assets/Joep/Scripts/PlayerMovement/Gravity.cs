using UnityEngine;

public class Gravity : Mover
{
    private Vector3 velocity;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    /// <summary>
    /// Apply gravity if the player isnt grounded
    /// </summary>
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
        _charCont.Move(velocity * Time.deltaTime);
    }

    public void TriggerJump()
    {
        if (_IsGrounded)
            Jump();
    }

    protected override void Jump()
    {
        base.Jump();

        velocity.y += PlayerMovement.Gravity * Time.deltaTime;

        _charCont.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _IsGrounded)
            velocity.y = Mathf.Sqrt(PlayerMovement.JumpHeight * -2f * PlayerMovement.Gravity);
    }
}
