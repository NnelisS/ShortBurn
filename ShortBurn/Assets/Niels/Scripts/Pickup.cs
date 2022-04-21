using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Pickup : MonoBehaviour
{
    public float pickupRange = 5;
    public float moveForce = 1;
    public Transform holdParent;
    private GameObject heldObject;
    public CinemachineVirtualCamera vcam;

    public float rotationSpeed = 5;
    private Vector3 turn;
    private bool rotateEnabled = false;

    void Update()
    {
        if (heldObject != null && rotateEnabled == false)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                rotateEnabled = true;
                vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 0;
                vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0;
                heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

        if (rotateEnabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                rotateEnabled = false;
                MoveObject();
            }
/*            turn.x = Input.GetAxis("Mouse X") * rotationSpeed;
            turn.y = Input.GetAxis("Mouse Y") * rotationSpeed;
            heldObject.transform.rotation = Quaternion.Euler(-turn.y, turn.x, 0);*/

            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Rad2Deg;
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Rad2Deg;
            heldObject.transform.Rotate(Vector3.forward, y);
            heldObject.transform.Rotate(Vector3.up, x);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickupUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                rotateEnabled = false;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ThrowObject();
                    heldObject = null;
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                rotateEnabled = false;
                MoveObject();
            }
        }
    }

    private void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDiretion = (holdParent.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDiretion * moveForce);
        }
    }

    private void PickupUpObject(GameObject pickObj)
    {
        pickObj.transform.localPosition = Vector3.Lerp(pickObj.transform.localPosition, holdParent.transform.localPosition, 1 * Time.deltaTime);

        if (pickObj.GetComponent<Rigidbody>())
        {
            pickObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObject = pickObj;
        }
    }

    private void ThrowObject()
    {
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;

        vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 800;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 800;

        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        heldObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        heldObject = null;
    }

    private void DropObject()
    {
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;

        vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 800;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 800;

        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        heldObject = null;
    }
}
