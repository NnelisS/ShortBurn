using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralSpider : MonoBehaviour
{   
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
        }
    }
}
