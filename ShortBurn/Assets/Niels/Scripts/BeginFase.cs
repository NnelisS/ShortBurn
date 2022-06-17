using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginFase : MonoBehaviour
{
    public GameObject virtualCam;

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
                virtualCam.SetActive(true);
                on = false;
            }
        }
    }
}
