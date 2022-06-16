using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnim : MonoBehaviour
{
    private Vector3 up;
    private Vector3 mid;
    private Vector3 Down;


    void Start()
    {
        up = new Vector3(transform.position.x, 0.1f, transform.position.z);
    }

    void Update()
    {
        if (Input.GetKey)
        {

        }    
    }
}
