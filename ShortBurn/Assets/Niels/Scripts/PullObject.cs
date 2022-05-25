using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PullObject : MonoBehaviour
{
    [Header("Pull Object Settings")]
    [SerializeField] private float pickupRange = 50;
    [SerializeField] private Transform middlePos;

    [Header("Pull Object Info")]
    [SerializeField] private RigiMovement playerMove;
    [SerializeField] private PlayerLook playerL;
    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private Transform grapplePoint;
    [SerializeField] private LineRenderer lr;
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
        // get picked object and render two lines between them smoothly
        if (heldObject != null && pickupScript.IsThrowing == false)
        {
            HasObj = true;
            lr.positionCount = 2;
            lr.SetPosition(0, gunPoint.position);
            lr.SetPosition(1, grapplePoint.position = Vector3.MoveTowards(grapplePoint.position, heldObject.transform.position, 5 * Time.maximumDeltaTime));
            vCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0;
            playerL.enabled = false;
            playerMove.enabled = false;

            // when line renderer reached picked object object is being pulled towards the player
            if (Vector3.Distance(grapplePoint.transform.position, heldObject.transform.position) <= 1.0f)
            {
                heldObject.transform.position = Vector3.MoveTowards(heldObject.transform.position, middlePos.transform.position, 3 * Time.maximumDeltaTime);
                if (Vector3.Distance(heldObject.transform.position, middlePos.position) <= 0.0f)
                    DropObject();
            }
        }
        else
        {
            HasObj = false;
            playerL.enabled = true;
            playerMove.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                    if (Vector3.Distance(gunPoint.transform.position, hit.point) > 5.0f)
                    PickupUpObject(hit.transform.gameObject);
            }

        if (heldObject != null)
            if (Input.GetKeyDown(KeyCode.E))
                MoveObject();
    }

    /// <summary>
    /// when press E on object it goes to the position it's suppose to be your pickup range
    /// </summary>
    private void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, middlePos.position) > 0.1f)
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

    /// <summary>
    /// when holding the object press e and it drops normal on the ground
    /// </summary>
    private void DropObject()
    {
        lr.positionCount = 0;
        grapplePoint.transform.position = gunPoint.transform.position;
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;

        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        heldObject = null;
    }
}
