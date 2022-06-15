using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    private Elevator elevator;

    private BoxCollider trigger;
    private BoxCollider boxCol;

    private void Start()
    {
        trigger = GetComponent<BoxCollider>();
        boxCol = GetComponentInChildren<BoxCollider>();
        elevator = GetComponentInParent<Elevator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ColliderChanges());
            StartCoroutine(elevator.ElevatorChange());
        }
    }

    private IEnumerator ColliderChanges()
    {
        trigger.enabled = false;
        boxCol.enabled = true;
        yield return new WaitForSeconds(2f);
        boxCol.enabled = false;
    }
}