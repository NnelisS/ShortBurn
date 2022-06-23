using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private CheckPointManager checkPointManager;
    private Controller cont;

    void Start()
    {
        cont = FindObjectOfType<Controller>();
        checkPointManager = FindObjectOfType<CheckPointManager>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            checkPointManager.Respawn();

        if (other.gameObject.CompareTag("Clone"))
            cont.DestroyClone();
    }
}