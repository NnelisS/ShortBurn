using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigOn : MonoBehaviour
{
    public Rigidbody rb;

    public ObjectRespawn Cube;

    void Start()
    {
        rb.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
        {
            Cube.ResetObject();

            if (rb.useGravity == false)
                rb.useGravity = true;
        }
    }
}
