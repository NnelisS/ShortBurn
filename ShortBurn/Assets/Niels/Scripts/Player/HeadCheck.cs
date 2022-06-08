using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HeadCheck : MonoBehaviour
{
    private CharacterController crouch;

    void Start()
    {
        crouch = FindObjectOfType<CharacterController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            crouch.CrouchUsable = false;
            crouch.GoCrouch();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            crouch.CrouchUsable = false;
            crouch.OutCrouch();
        }
    }
}
