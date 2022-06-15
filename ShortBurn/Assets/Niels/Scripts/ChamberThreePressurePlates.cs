using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberThreePressurePlates : MonoBehaviour
{
    public bool Move = false;

    private void OnTriggerStay(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
            Move = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
            Move = false;
    }
}
