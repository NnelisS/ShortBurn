using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberThreePressurePlates : MonoBehaviour
{
    public bool Move = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            Move = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            Move = false;
    }
}
