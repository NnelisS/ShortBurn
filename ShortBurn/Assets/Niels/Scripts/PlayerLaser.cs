using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    private CheckPointManager checkPointManager;

    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            checkPointManager.Respawn();
        }
    }
}
