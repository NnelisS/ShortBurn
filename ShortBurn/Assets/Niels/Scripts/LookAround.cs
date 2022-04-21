using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform body;
    public float speed = 3;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

	void Update()
	{
        transform.rotation = Quaternion.Euler(transform.rotation.x, body.rotation.y, transform.rotation.z);
	}
}
