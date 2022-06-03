using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Pickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] private float pickupRange = 5;
    [SerializeField] private float moveForce = 1;
    [SerializeField] private Transform middlePos;
    [SerializeField] private float rotationSpeed = 5;

    [Header("Pickup Info")]
    [SerializeField] private PlayerLook playerL;
    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private LayerMask pickupLayer;
    private PullObject PullObjScript;
    private LineRenderer line;

    [Header("Throw Settings")]
    [SerializeField] private float timer = 1;
    private bool throwIt = false;
    private bool letGo = false;
    public bool IsThrowing = false;

    [HideInInspector] public GameObject heldObject;
    private float currentMass = 1;

    private Vector3 turn;
    public bool RotateEnabled = false;

    private void Start()
    {
        line = middlePos.gameObject.GetComponent<LineRenderer>();
        PullObjScript = GetComponent<PullObject>();
    }

    void Update()
    {
        // move picked object to hold position and keep moving it towards
        if (heldObject != null && RotateEnabled == false)
        {
            line.positionCount = 0;

            if (Vector3.Distance(heldObject.transform.position, middlePos.position) > 0.0f)
            {
                Vector3 moveDiretion = (middlePos.position - heldObject.transform.position);
                heldObject.GetComponent<Rigidbody>().AddForce(moveDiretion * moveForce);
                heldObject.GetComponent<Rigidbody>().AddForce(-transform.up * heldObject.GetComponent<Rigidbody>().mass * 35);
            }

            if (heldObject.GetComponent<Rigidbody>().mass < 3)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    RotateEnabled = true;
                    playerL.ChangeMovement();
                    heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                }
            }
        }

        // enable object rotation while holding it
        if (RotateEnabled)
        {
            Vector3 moveDiretion = (middlePos.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDiretion * moveForce);

            RotateObject();
        }

        // pickup object when pressing e
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, pickupLayer))
                    PickupUpObject(hit.transform.gameObject);
            }
            else if (throwIt == false)
            {
                DropObject();
                playerL.ChangeMovement();
            }
        }

        if (heldObject != null)
        {
            line.positionCount = 2;
            line.SetPosition(0, middlePos.position);
            line.SetPosition(1, heldObject.transform.position);

            float _distanceBetweenObj = Vector3.Distance(middlePos.transform.position, heldObject.transform.position);
            if (_distanceBetweenObj > 1.4f)
                DropObject();
            else
            {
                if (heldObject.GetComponent<Rigidbody>().mass < 3)
                {
                    // if mouse is being hold, fov goes up and you throw harder the longer you hold it
                    if (Input.GetKey(KeyCode.Mouse0) && PullObjScript.HasObj == false)
                    {
                        if (_distanceBetweenObj > 1.4f)
                        {
                            DropObject();
                            letGo = true;
                            throwIt = false;
                            vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 60, 10 * Time.maximumDeltaTime);
                        }
                        else
                        {
                            IsThrowing = true;
                            vCam.m_Lens.FieldOfView += 5 * Time.deltaTime;
                            timer -= 0.1f * Time.deltaTime;
                            heldObject.GetComponent<Rigidbody>().mass = timer;
                            throwIt = true;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
                RotateEnabled = false;
        }
        else if (heldObject == null)
            playerL.movementOn = true;

        // throw the object and throw fov back to default
        if (letGo)
        {
            IsThrowing = false;
            vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 60, 10 * Time.maximumDeltaTime);
            if (vCam.m_Lens.FieldOfView == 60)
            {
                letGo = false;
            }
        }

        // let go off object and throw it with the force it has
        if (throwIt)
        {
            if (letGo == false && Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (RotateEnabled)
                    playerL.ChangeMovement();

                heldObject.GetComponent<Rigidbody>().mass += currentMass * 3;
                line.positionCount = 0;
                letGo = true;
                RotateEnabled = false;
                timer = 1;
                ThrowObject();
                heldObject = null;
                throwIt = false;
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1;
            }
        }

        // if your on full force for throwing the frequency of the camera shake spikes up
        if (timer <= 0.3f)
        {
            timer = 0.3f;
            vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 10;
            vCam.m_Lens.FieldOfView = 86.6f;
        }
    }

    private void RotateObject()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            RotateEnabled = false;
            playerL.ChangeMovement();
        }

        if (Input.GetKeyDown(KeyCode.E))
            RotateEnabled = false;

        // rotate object with mouse movement
        float xInput = Input.GetAxis("Mouse X");
        float yInput = Input.GetAxis("Mouse Y");
        turn.x += xInput * rotationSpeed;
        turn.y += yInput * rotationSpeed;

        Transform cameraTransform = Camera.main.transform;

#pragma warning disable CS0618 // Type or member is obsolete
        heldObject.transform.RotateAround(cameraTransform.up, xInput * Time.deltaTime * rotationSpeed);
        heldObject.transform.RotateAround(cameraTransform.right, -yInput * Time.deltaTime * rotationSpeed);
#pragma warning restore CS0618 // Type or member is obsolete
    }

    /// <summary>
    /// get information on picked object
    /// </summary>
    /// <param name="pickObj"></param>
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
    /// throw object with information from mouse hold
    /// </summary>
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

    /// <summary>
    /// when holding the object press e and it drops normal on the ground
    /// </summary>
    private void DropObject()
    {
        line.positionCount = 0;
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;

        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        heldObject = null;

        if (RotateEnabled)
            playerL.ChangeMovement();
    }

    public void DropObj()
    {
        line.positionCount = 0;
        heldObject.GetComponent<Rigidbody>().useGravity = true;

        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        heldObject = null;

        if (RotateEnabled)
            playerL.ChangeMovement();
    }
}
