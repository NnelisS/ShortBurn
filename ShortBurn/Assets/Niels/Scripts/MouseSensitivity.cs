using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    private Slider sensChange;
    private PlayerLook playerL;

    void Start()
    {
        sensChange = GetComponentInChildren<Slider>();
        playerL = FindObjectOfType<PlayerLook>();
    }

    void Update()
    {
        playerL.MouseSensitivity = sensChange.value;
    }
}
