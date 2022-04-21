using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Pickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    public float pickupRange = 5;
    public float moveForce = 1;
    public Transform holdParent;
    public Transform middlePos;
    public float rotationSpeed = 5;

    [Header("Pickup Info")]
    public PlayerLook playerL;

    [Header("Throw Settings")]
    public float timer = 1;
    public bool throwIt = false;

    public GameObject heldObject;

    private Vector3 turn;
    private bool rotateEnabled = false;

    void Update()
    {
        if (heldObject != null && rotateEnabled == false)
        {
/*            heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, middlePos.transform.position, 0.5f * Time.deltaTime);
*/
            heldObject.transform.position = Vector3.MoveTowards(heldObject.transform.position, middlePos.transform.position, 1f * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.R))
            {
                rotateEnabled = true;
                heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

        if (rotateEnabled)
        {
            playerL.mouseSensitivity = 0;

            if (Input.GetKeyUp(KeyCode.R))
                rotateEnabled = false;

            if (Input.GetKeyDown(KeyCode.E))
            {
                rotateEnabled = false;
                MoveObject();
            }

            turn.x += Input.GetAxis("Mouse X") * rotationSpeed;
            turn.y += Input.GetAxis("Mouse Y") * rotationSpeed;
            heldObject.transform.rotation = Quaternion.Euler(-turn.y, turn.x, heldObject.transform.rotation.z);

            /*            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Rad2Deg;
                        float x = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Rad2Deg;
                        heldObject.transform.Rotate(Vector3.forward, y);
                        heldObject.transform.Rotate(Vector3.up, x);*/
        }
        else
        {
            playerL.mouseSensitivity = 100;
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
            if (Input.GetKey(KeyCode.Mouse0))
            {
                timer -= 0.90f * Time.deltaTime;
                heldObject.GetComponent<Rigidbody>().mass = timer;

                throwIt = true;
                rotateEnabled = false;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                rotateEnabled = false;
                MoveObject();
            }
        }

        if (throwIt)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                timer = 5;
                ThrowObject();
                heldObject = null;
                throwIt = false;
            }
        }

        if (timer <= 0.30f)
            timer = 0.30f;
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

        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        heldObject = null;
    }
}
