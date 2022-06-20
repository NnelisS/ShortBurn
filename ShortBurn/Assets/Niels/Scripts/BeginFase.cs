using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BeginFase : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;

    private bool on = false;
    private float timer = 23;

    void Start()
    {
        on = true;
    }

    void Update()
    {
        if (on)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Debug.Log("On");
                virtualCam.enabled = true;
                on = false;
            }
        }
    }
}
