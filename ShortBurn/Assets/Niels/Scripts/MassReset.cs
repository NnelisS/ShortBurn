using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassReset : MonoBehaviour
{
    private Rigidbody rb;
    private float MassResetValue;

    private void Start()
    {
        MassResetValue = GetComponent<Rigidbody>().mass;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            rb.mass = MassResetValue;
    }
}
