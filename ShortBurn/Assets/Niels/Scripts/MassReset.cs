using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassReset : MonoBehaviour
{
    private Rigidbody rb;
    private float MassResetValue;
    public ParticleSystem Impact;

    private void Start()
    {
        MassResetValue = GetComponent<Rigidbody>().mass;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (rb.velocity.y > 0)
                StartCoroutine(SmokeImpact(collision.transform));
            rb.mass = MassResetValue;
        }
    }

    private IEnumerator SmokeImpact(Transform hitPos)
    {
        Debug.Log("Smoke");
        ParticleSystem smoke = Instantiate(Impact, hitPos.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Destroy(smoke);
    }
}
