using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberOneManager : MonoBehaviour
{
    public ChamberOnePressurePlate[] ChamberPressurePlates;
    public Rigidbody Battery;

    private Animator clawOpen;

    private void Update()
    {
        for (int i = 0; i < ChamberPressurePlates.Length; i++)
        {
            if (ChamberPressurePlates[i].On == true)
            {
                clawOpen.Play("Claw1");
                Battery.useGravity = true;
            }
        }
    }
}
