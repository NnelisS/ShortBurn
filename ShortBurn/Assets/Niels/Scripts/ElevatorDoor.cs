using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public Battery[] Batteries;

    void Update()
    {
        for (int i = 0; i < Batteries.Length; i++)
        {
            if (Batteries[i].BatteryIn == true)
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 1.5f, transform.position.z), 1 * Time.deltaTime);
            else if (Batteries[i].BatteryIn == false)
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, transform.position.z), 1 * Time.deltaTime);
        }
    }
}
