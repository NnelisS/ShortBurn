using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [Header("Settings")]
    public float speed = 12;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("ground Info")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Jump();
        Running();
        GroundCheck();

        // get input axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // use character controller to move around
        controller.Move(move * speed * Time.deltaTime);
    }

    #region Running
    private void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12;
        }
        else
        {
            speed = 5;
        }
    }
    #endregion

    #region GroundCheck
    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }
    }
    #endregion

    #region Jump
    private void Jump()
    {
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    #endregion

}
