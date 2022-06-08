using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EndPuzzle : MonoBehaviour
{
    public Battery[] Batteries;
    public Rigidbody[] RB;

    private Animator clawAnim;

    private void Start()
    {
        clawAnim = GetComponent<Animator>();
        for (int i = 0; i < RB.Length; i++)
        {
            RB[i].useGravity = false;
        }
    }

    void Update()
    {
        if (Batteries[0].BatteryIn == true)
        {
            clawAnim.Play("Claw_Open_1");
            Batteries[0].BatteryIn = false;
            RB[0].useGravity = true;
        }
        if (Batteries[1].BatteryIn == true)
        {
            clawAnim.Play("Claw_Open_2");
            Batteries[1].BatteryIn = false;
            RB[1].useGravity = true;
        }
        if (Batteries[2].BatteryIn == true)
        {
            clawAnim.Play("Claw_Open_3");
            Batteries[2].BatteryIn = false;
            RB[2].useGravity = true;
        }
    }
}
