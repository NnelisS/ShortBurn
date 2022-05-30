using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [Header("ground Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody rb;

    private bool isGrounded;

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
        if (other.gameObject.CompareTag("PlayerGround"))
            groundMask = LayerMask.NameToLayer("Default");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerGround") && isGrounded)
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerGround"))
        {
            rb.constraints = RigidbodyConstraints.None;
            groundMask = LayerMask.NameToLayer("Pickups");
        }
    }

    #region GroundCheck
    private void GroundChecker()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, 0.1f);
    }
}
