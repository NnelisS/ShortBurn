using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberOneManager : MonoBehaviour
{
    public ChamberOnePressurePlate[] ChamberPressurePlates;
    public Rigidbody Battery;

    public Animator clawOpen;

    private void Update()
    {
        if (ChamberPressurePlates[0].On == true && ChamberPressurePlates[1].On == true)
        {
            Battery.useGravity = true;
            clawOpen.Play("Claw1");
        }
    }
}
