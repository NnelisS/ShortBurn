using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    private bool enableClone = false;

    private void Update()
    {
        if (enableClone)
        {
            Debug.Log("clone Is Active");

            MoveForward();
        }
    }

    private void OnMouseEnter()
    {
        Debug.Log("On Clone");
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            enableClone = true;
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
