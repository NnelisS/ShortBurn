using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public bool EnableClone = false;
    public PlayerMovement PlayerMov;

    private void Update()
    {
        // let clone move forward
        if (EnableClone)
        {
            PlayerMov.enabled = true;
            /*MoveForward();*/
        }
    }

    private void OnMouseEnter()
    {
        if (Input.GetKeyDown(KeyCode.E))
            EnableClone = true;
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
