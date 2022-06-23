using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BridgePuzzle : MonoBehaviour
{
    public Transform Bridge;
    public Transform GoTo;
    public Transform GoToBack;
    public bool ClonePuzzle = false;

    private float timer = 2;
    private CinemachineVirtualCamera vCam;

    private bool activated = false;

    public AudioSource Ending;

    private void Start()
    {
        vCam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (activated)
        {
            if (ClonePuzzle)
                Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoTo.transform.localPosition, 0.3f * Time.deltaTime);
            else
                Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoTo.transform.localPosition, 1 * Time.deltaTime);
        }
        else
        {
            if (ClonePuzzle == false)
                Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoToBack.transform.localPosition, 1 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Ending != null)
        {
            if (other.gameObject.CompareTag("Clone"))
            {
                if (ClonePuzzle)
                    Ending.enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
            activated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
            activated = false;
    }
}
