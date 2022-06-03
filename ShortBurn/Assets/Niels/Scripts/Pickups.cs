using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [Header("ground Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerGround") && isGrounded)
            groundMask = LayerMask.NameToLayer("Default");
        else if (!isGrounded)
            transform.gameObject.tag = "Untagged";
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerGround"))
        {
            rb.constraints = RigidbodyConstraints.None;
            groundMask = LayerMask.NameToLayer("Pickups");
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
