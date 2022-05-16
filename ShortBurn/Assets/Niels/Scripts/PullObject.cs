using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PullObject : MonoBehaviour
{
    [Header("Pull Object Settings")]
    public float PickupRange = 50;
    public float MoveForce = 100;
    public Transform MiddlePos;

    [Header("Pull Object Info")]
    public RigiMovement PlayerMove;
    public PlayerLook PlayerL;
    public CinemachineVirtualCamera VCam;
    public Transform GunPoint;
    public Transform GrapplePoint;
    private LineRenderer lr;
    private Pickup pickupScript;
    public bool HasObj = false;

    private GameObject heldObject;

    private void Start()
    {
        pickupScript = GetComponent<Pickup>();
        lr = GetComponentInChildren<LineRenderer>();
    }

    void Update()
    {
        if (heldObject != null && pickupScript.IsThrowing == false)
        {
            HasObj = true;
            lr.positionCount = 2;
            lr.SetPosition(0, GunPoint.position);
            lr.SetPosition(1, GrapplePoint.position = Vector3.MoveTowards(GrapplePoint.position, heldObject.transform.position, 5 * Time.maximumDeltaTime));
            VCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0;
            PlayerL.enabled = false;
            PlayerMove.enabled = false;

            if (Vector3.Distance(GrapplePoint.transform.position, heldObject.transform.position) <= 1.0f)
            {
                heldObject.transform.position = Vector3.MoveTowards(heldObject.transform.position, MiddlePos.transform.position, 3 * Time.maximumDeltaTime);
                if (Vector3.Distance(heldObject.transform.position, MiddlePos.position) <= 0.0f)
                    DropObject();
            }
        }
        else
        {
            HasObj = false;
            VCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 150;
            PlayerL.enabled = true;
            PlayerMove.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, PickupRange))
                    if (Vector3.Distance(GunPoint.transform.position, hit.point) > 5.0f)
                    PickupUpObject(hit.transform.gameObject);
            }

        if (heldObject != null)
            if (Input.GetKeyDown(KeyCode.E))
                MoveObject();
    }

    //when press E on object it goes to the position it's suppose to be your pickup range
    private void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, MiddlePos.position) > 0.1f)
        {
            /*Vector3 moveDiretion = (MiddlePos.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDiretion * MoveForce);*/
        }
    }

    private void PickupUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            pickObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;
            heldObject = pickObj;
        }
    }

    // when holding the object press e and it drops normal on the ground
    private void DropObject()
    {
        lr.positionCount = 0;
        GrapplePoint.transform.position = GunPoint.transform.position;
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;

        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        heldObject = null;
    }
}
