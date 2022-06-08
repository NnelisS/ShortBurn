using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberOnePressurePlate : MonoBehaviour
{
    public bool On = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            On = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            On = false;
    }
}
