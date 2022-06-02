using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject Player;
    public GameObject Capsule;

    public UnityEngine.CharacterController CharacterCont;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Capsule)
        {
            CharacterCont.enabled = false;
            Player.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Capsule)
        {
            Player.transform.SetParent(null);
        }
    }
}
