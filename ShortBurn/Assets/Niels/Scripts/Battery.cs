using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public bool BatteryIn = false;
    public MeshCollider childCol;
    private Pickup pickup;

    private void Start()
    {
        pickup = FindObjectOfType<Pickup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BatteryHolder"))
        {
            pickup.DropObj();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            BatteryIn = true;
            
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            childCol.enabled = false;
        }
    }
}
