using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public bool enableClone = false;
    public PlayerMovement playerMov;

    private void Update()
    {
        if (enableClone)
        {
            Debug.Log("clone Is Active");
            playerMov.enabled = true;
            /*MoveForward();*/
        }
    }

    private void OnMouseEnter()
    {
        Debug.Log("On Clone"); 
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
