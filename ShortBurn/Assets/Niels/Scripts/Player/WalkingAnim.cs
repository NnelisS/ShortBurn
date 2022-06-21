using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnim : MonoBehaviour
{
    private Animator walkAnim;

    private CharacterController charCont;

    void Start()
    {
        charCont = FindObjectOfType<CharacterController>();
        walkAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (charCont.isActiveAndEnabled)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                walkAnim.SetBool("IsWalking", true);
            else
                walkAnim.SetBool("IsWalking", false);
        }
    }
}
