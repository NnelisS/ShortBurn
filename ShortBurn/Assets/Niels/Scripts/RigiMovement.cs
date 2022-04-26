using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigiMovement : MonoBehaviour
{
    public Rigidbody Rigid;

    [Header("Movement Settings")]
    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;

    [Header("ground Info")]
    public Transform GroundChecker;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    private Vector3 velocity;
    private bool isGrounded;
    void Update()
    {
        Jump();
        GroundCheck();

        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        if (Input.GetKeyDown("space"))
            Rigid.AddForce(transform.up * JumpForce);
    }



    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(GroundChecker.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

}
