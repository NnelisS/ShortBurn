using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawn : MonoBehaviour
{
    private Vector3 backPos;

    void Start()
    {
        backPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            ResetObject();
        }
    }

    public void ResetObject()
    {
        transform.position = backPos;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
