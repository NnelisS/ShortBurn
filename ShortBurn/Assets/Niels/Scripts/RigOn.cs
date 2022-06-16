using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigOn : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
            rb.useGravity = true;
    }
}
