using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [Header("ground Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask ground;

    private Rigidbody rb;

    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        GroundChecker();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isGrounded == false)
                collision.gameObject.GetComponent<Gravity>().DisableJump = true;
            else if (isGrounded)
                collision.gameObject.GetComponent<Gravity>().DisableJump = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerGround") && isGrounded)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            transform.gameObject.tag = "CubeNormal";
        }
        else
            transform.gameObject.tag = "Untagged";
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isGrounded == false)
                collision.gameObject.GetComponent<Gravity>().DisableJump = true;
            else if (isGrounded)
                collision.gameObject.GetComponent<Gravity>().DisableJump = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerGround"))
        {
            rb.constraints = RigidbodyConstraints.None;
            transform.gameObject.tag = "CubeNormal";
        }
    }

    #region GroundCheck
    private void GroundChecker()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, 0.1f);
    }
}
