using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGlow : MonoBehaviour
{
    public GameObject Glow;

    public void On()
    {
        Glow.SetActive(true);
    }

    public void Off()
    {
        Glow.SetActive(false);
    }
}
