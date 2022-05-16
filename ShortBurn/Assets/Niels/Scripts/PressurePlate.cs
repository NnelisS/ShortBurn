using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Transform GoTo;
    public Transform GoToBack;
    public Transform Plate;

    private bool onCol = true;

    void Update()
    {
        //ignore plate collision with pressureplate
        Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), Plate.GetComponent<BoxCollider>());

        //move pressure plat down
        if (onCol)
            transform.localPosition = Vector3.Lerp(transform.localPosition, GoTo.localPosition, 5 * Time.deltaTime);
        else if (onCol == false)
            transform.localPosition = Vector3.Lerp(transform.localPosition, GoToBack.localPosition, 5 * Time.deltaTime);
    }

    // check for player and block collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CubeNormal") || collision.gameObject.CompareTag("Player"))
            onCol = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("CubeNormal") || collision.gameObject.CompareTag("Player"))
            onCol = true;
    }
}
