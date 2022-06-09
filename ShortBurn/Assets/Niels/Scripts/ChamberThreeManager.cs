using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberThreeManager : MonoBehaviour
{
    public ChamberThreePressurePlates[] PressurePlates;
    public GameObject Platform;

    public Animator Claw;
    public Rigidbody Battery;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PressurePlates[0].Move)
            Platform.SetActive(true);

        if (PressurePlates[1].Move && PressurePlates[2].Move)
        {
            Debug.Log("work");
            Claw.Play("Claw1");
            Battery.useGravity = true;
        }
    }
}
