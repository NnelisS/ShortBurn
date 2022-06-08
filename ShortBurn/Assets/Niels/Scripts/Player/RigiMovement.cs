using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RigiMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("ground Info")]
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask groundMaskCube;

    [Header("Player Info")]
    [SerializeField] private Transform playerHeight;
    [SerializeField] private GameObject playerCapsule;
    private CinemachineVirtualCamera vCam;
    private Pickup pickupScript;

    public bool IsCrouched = false;
    private Vector3 velocity;
    private bool isGrounded;
    private Rigidbody Rigid;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        //pickupScript = GetComponentInChildren<Pickup>();
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    void Update()
    {
        //Crouch();
        Jump();
        GroundCheck();

        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));
    }

    /// <summary>
    /// if pressing crouch button move player down and scale down movement speed and fov
    /// </summary>
    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            IsCrouched = true;
            if (pickupScript.IsThrowing == false)
                vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 52, 4 * Time.maximumDeltaTime);

            playerHeight.transform.localPosition = new Vector3(playerHeight.transform.localPosition.x, Mathf.MoveTowards(playerHeight.transform.localPosition.y, 0, 0.5f * Time.maximumDeltaTime), playerHeight.transform.localPosition.z);
            playerCapsule.transform.localScale = new Vector3(playerCapsule.transform.localScale.x, Mathf.Lerp(playerCapsule.transform.localScale.y, 0.5f, 0.5f * Time.maximumDeltaTime), playerCapsule.transform.localScale.z);
            moveSpeed = 0.03f;
        }
        else
        {
            IsCrouched = false;
            playerHeight.transform.localPosition = new Vector3(playerHeight.transform.localPosition.x, Mathf.MoveTowards(playerHeight.transform.localPosition.y, 0.75f, 0.5f * Time.maximumDeltaTime), playerHeight.transform.localPosition.z);
            playerCapsule.transform.localScale = new Vector3(playerCapsule.transform.localScale.x, Mathf.Lerp(playerCapsule.transform.localScale.y, 1, 0.5f * Time.maximumDeltaTime), playerCapsule.transform.localScale.z);
            if (pickupScript.IsThrowing == false)
            {
                vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 60, 4 * Time.maximumDeltaTime);
                moveSpeed = 0.1f;
            }
        }
    }

    /// <summary>
    /// check if player interacts with ground
    /// </summary>
    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -0.5f;
    }

    // when pressing jump button player goes up with force 
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
