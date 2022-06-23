using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public BoxCollider BoxCol;

    private Elevator elevator;

    private BoxCollider trigger;

    private void Start()
    {
        trigger = GetComponent<BoxCollider>();
        elevator = GetComponentInParent<Elevator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BoxCol.enabled = true;
            StartCoroutine(ColliderChanges());
            StartCoroutine(elevator.ElevatorChange());
        }
    }

    private IEnumerator ColliderChanges()
    {
        trigger.enabled = false;
        BoxCol.enabled = true;
        yield return new WaitForSeconds(2f);
        BoxCol.enabled = false;
    }
}