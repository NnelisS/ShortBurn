using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Pickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    public float PickupRange = 5;
    public float MoveForce = 1;
    public Transform MiddlePos;
    public float RotationSpeed = 5;

    [Header("Pickup Info")]
    public PlayerLook PlayerL;
    public CinemachineVirtualCamera VCam;
    private PullObject PullObjScript;

    [Header("Throw Settings")]
    public float Timer = 1;
    private bool throwIt = false;
    private bool letGo = false;
    public bool IsThrowing = false;

    private GameObject heldObject;

    private Vector3 turn;
    private bool rotateEnabled = false;

    private void Start()
    {
        PullObjScript = GetComponent<PullObject>();
    }

    void Update()
    {
        if (heldObject != null && rotateEnabled == false)
        {
            if (Vector3.Distance(heldObject.transform.position, MiddlePos.position) > 0.0f)
            {
                Vector3 moveDiretion = (MiddlePos.position - heldObject.transform.position);
                heldObject.GetComponent<Rigidbody>().AddForce(moveDiretion * MoveForce);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                rotateEnabled = true;
                heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

        // enable object rotation while holding it
        if (rotateEnabled)
        {
            PlayerL.MouseSensitivity = 0;
            VCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0;

            if (Input.GetKeyUp(KeyCode.R))
                rotateEnabled = false;

            if (Input.GetKeyDown(KeyCode.E))
            {
                rotateEnabled = false;
                MoveObject();
            }

            // rotate object with mouse movement
            turn.x += Input.GetAxis("Mouse X") * RotationSpeed;
            turn.y += Input.GetAxis("Mouse Y") * RotationSpeed;

            heldObject.transform.rotation = Quaternion.Euler(-turn.y, turn.x, heldObject.transform.rotation.z);

            /*            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Rad2Deg;
                        float x = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Rad2Deg;
                        heldObject.transform.Rotate(Vector3.forward, y);
                        heldObject.transform.Rotate(Vector3.up, x);*/
        }
        else if (rotateEnabled == false && PullObjScript.HasObj == false) 
        {
            PlayerL.MouseSensitivity = 100;
            VCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 150;
        }

        // pickup object when pressing e

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, PickupRange))
                {
                    PickupUpObject(hit.transform.gameObject);
                    if (PickupRange > 50)
                    {

                    }
                }
            }
            else if(throwIt == false)
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            // if mouse is being hold, fov goes up and you throw harder the longer you hold it
            if (Input.GetKey(KeyCode.Mouse0) && PullObjScript.HasObj == false)
            {
                IsThrowing = true;
                VCam.m_Lens.FieldOfView += 5 * Time.deltaTime;
                Timer -= 0.90f * Time.deltaTime;
                heldObject.GetComponent<Rigidbody>().mass = Timer;

                throwIt = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                rotateEnabled = false;
                MoveObject();
            }
        }

        // throw the object and throw fov back to default
        if (letGo)
        {
            IsThrowing = false;
            VCam.m_Lens.FieldOfView = Mathf.MoveTowards(VCam.m_Lens.FieldOfView, 60, 10 * Time.maximumDeltaTime);
            if (VCam.m_Lens.FieldOfView == 60)
            {
                letGo = false;
            }
        }

        if (throwIt)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                letGo = true;
                rotateEnabled = false;
                Timer = 5;
                ThrowObject();
                heldObject = null;
                throwIt = false;
                VCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1;
            }
        }

        if (Timer <= 0.30f)
        {
            Timer = 0.30f;
            VCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 10;
            VCam.m_Lens.FieldOfView = 86.6f;
        }
    }

    //when press E on object it goes to the position it's suppose to be your pickup range
    private void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, MiddlePos.position) > 0.1f)
        {
            Vector3 moveDiretion = (MiddlePos.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDiretion * MoveForce);
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

    // throw object with information from mouse hold
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

    // when holding the object press e and it drops normal on the ground
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
