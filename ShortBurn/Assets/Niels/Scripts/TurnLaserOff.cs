using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLaserOff : MonoBehaviour
{
    public MeshRenderer Laser;
    public BoxCollider BoxCol;

    private void OnTriggerEnter(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
        {
            Laser.enabled = false;
            BoxCol.enabled = false;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
        {
            Laser.enabled = true;
            BoxCol.enabled = true;
        }
    }
}
