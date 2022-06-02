using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private CheckPointManager checkPointManager;

    void Start()
    {
        checkPointManager = FindObjectOfType<CheckPointManager>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            checkPointManager.Respawn();
    }
}
