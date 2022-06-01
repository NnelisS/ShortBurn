using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject player;

    public UnityEngine.CharacterController CharacterCont;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            CharacterCont.enabled = false;
            player.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.SetParent(null);
        }
    }
}
