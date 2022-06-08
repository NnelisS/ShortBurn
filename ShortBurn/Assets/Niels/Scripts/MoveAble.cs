using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAble : MonoBehaviour
{
    public Transform NormalPos;
    public Transform BackPos;

    public Transform Block;
    public Transform BlockPos;
    public Transform BlockPosBack;

    public ChamberTwoPressurePlate[] PressurePlates;
    public Rigidbody Battery;
    public Animator Claw;


    void Update()
    {
        if (PressurePlates[0].Move)
            transform.position = Vector3.MoveTowards(transform.position, BackPos.position, 1 * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, NormalPos.position, 1 * Time.deltaTime);

        if (PressurePlates[1].Move)
        {
            Block.transform.position = Vector3.MoveTowards(Block.transform.position, BlockPosBack.position, 1 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, BackPos.position, 1 * Time.deltaTime);
        }
        else
        {
            Block.transform.position = Vector3.MoveTowards(Block.transform.position, BlockPos.position, 1 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, NormalPos.position, 1 * Time.deltaTime);
        }

        if (PressurePlates[2].Move)
        {
            Claw.Play("Claw1");
            Battery.useGravity = true;
        }
    }
}
