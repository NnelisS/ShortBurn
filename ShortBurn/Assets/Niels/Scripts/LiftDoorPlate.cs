using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDoorPlate : MonoBehaviour
{
    public Transform Plate;
    public Transform BackPos;
    public Transform Pos;

    private bool On = false;

    void Update()
    {
        if (On)
            Plate.transform.position = Vector3.MoveTowards(Plate.transform.position, Pos.position, 1 * Time.deltaTime);
        else
            Plate.transform.position = Vector3.MoveTowards(Plate.transform.position, BackPos.position, 1 * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
            On = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
            On = false;
    }
}
