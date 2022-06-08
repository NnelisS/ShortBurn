using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberOnePressurePlate : MonoBehaviour
{
    public bool On = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Clone"))
            On = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Clone"))
            On = false;
    }
}
