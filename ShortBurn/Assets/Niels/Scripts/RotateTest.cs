using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RotateTest : MonoBehaviour
{
    private Animator rotaterTest;
    [SerializeField] private float rotaterValue;

    void Start()
    {
        rotaterTest = GetComponent<Animator>();    
    }

    void Update()
    {
        rotaterTest.speed = rotaterValue;

        if (rotaterValue >= 1.0f)
            rotaterValue = 1;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            rotaterValue += 0.1f;

        if (rotaterValue > 0 && Input.GetAxis("Mouse ScrollWheel") == 0f)
            rotaterValue -= 0.5f * Time.deltaTime;

        if (rotaterValue < 0) 
            rotaterValue = 0;
    }
}
