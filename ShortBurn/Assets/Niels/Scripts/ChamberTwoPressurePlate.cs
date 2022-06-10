using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberTwoPressurePlate : MonoBehaviour
{
    public bool Move = false;

    private void OnTriggerStay(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
        {
            Move = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
        {
            Move = false;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("CubeNormal"))
        {
            Move = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("CubeNormal"))
        {
            Move = false;
        }
    }

    /*    private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Clone"))
                Move = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Clone"))
                Move = true;
        }*/
}
