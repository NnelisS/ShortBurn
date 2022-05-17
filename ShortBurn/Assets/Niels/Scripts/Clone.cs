using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    [SerializeField] private bool enableClone = false;
    [SerializeField] private PlayerMovement playerMov;

    private void Update()
    {
        // let clone move forward
        if (enableClone)
        {
            /*PlayerMov.enabled = true;*/
            MoveForward();
        }
    }

    private void OnMouseEnter()
    {
        if (Input.GetKeyDown(KeyCode.E))
            enableClone = true;
    }
    private void OnMouseDown()
    {
        enableClone = true;
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
