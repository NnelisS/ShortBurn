using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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

    [Header("Player Info")]
    public Transform PlayerHeight;
    public GameObject PlayerCapsule;
    private CinemachineVirtualCamera vCam;
    private Pickup pickupScript;

    public bool IsCrouched = false;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        pickupScript = GetComponentInChildren<Pickup>();
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    void Update()
    {
        Crouch();
        Jump();
        GroundCheck();

        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        if (Input.GetKeyDown("space"))
            Rigid.AddForce(transform.up * JumpForce);
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            IsCrouched = true;
            if (pickupScript.IsThrowing == false)
                vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 52, 4 * Time.maximumDeltaTime);

            PlayerHeight.transform.localPosition = new Vector3(PlayerHeight.transform.localPosition.x, Mathf.MoveTowards(PlayerHeight.transform.localPosition.y, 0, 0.5f * Time.maximumDeltaTime), PlayerHeight.transform.localPosition.z);
            PlayerCapsule.transform.localScale = new Vector3(PlayerCapsule.transform.localScale.x, Mathf.Lerp(PlayerCapsule.transform.localScale.y, 0.5f, 0.5f * Time.maximumDeltaTime), PlayerCapsule.transform.localScale.z);
            MoveSpeed = 0.03f;
        }
        else
        {
            IsCrouched = false;
            PlayerHeight.transform.localPosition = new Vector3(PlayerHeight.transform.localPosition.x, Mathf.MoveTowards(PlayerHeight.transform.localPosition.y, 0.75f, 0.5f * Time.maximumDeltaTime), PlayerHeight.transform.localPosition.z);
            PlayerCapsule.transform.localScale = new Vector3(PlayerCapsule.transform.localScale.x, Mathf.Lerp(PlayerCapsule.transform.localScale.y, 1, 0.5f * Time.maximumDeltaTime), PlayerCapsule.transform.localScale.z);
            if (pickupScript.IsThrowing == false)
            {
                vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 60, 4 * Time.maximumDeltaTime);
                MoveSpeed = 0.1f;
            }
        }
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
