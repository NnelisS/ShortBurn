using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BridgePuzzle : MonoBehaviour
{
    public Transform Bridge;
    public Transform GoTo;
    public Transform GoToBack;

    public bool Activated = false;

    private void Update()
    {
        if (Activated)
            Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoTo.transform.localPosition, 1 * Time.deltaTime);
        else
            Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoToBack.transform.localPosition, 1 * Time.deltaTime);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Clone"))
            Activated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            Activated = false;
    }
}
