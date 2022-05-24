using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private UnityEngine.CharacterController controller;

    [Header("Settings")]
    public float Speed = 12;
    public float Gravity = -9.81f;
    public float JumpHeight = 3f;

    [Header("ground Info")]
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<UnityEngine.CharacterController>();
    }

    void Update()
    {
        Jump();
        Running();
        GroundChecker();

        // get input axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // use character controller to move around
        controller.Move(move * Speed * Time.deltaTime);
    }

    #region Running
    private void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            Speed = 12;
        else
            Speed = 5;
    }
    #endregion

    #region GroundCheck
    private void GroundChecker()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -0.5f;
    }
    #endregion

    #region Jump
    private void Jump()
    {
        velocity.y += Gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
    }
    #endregion
}