using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnim : MonoBehaviour
{
    private Animator walkAnim;

    void Start()
    {
        walkAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            walkAnim.SetBool("IsWalking", true);
        else
            walkAnim.SetBool("IsWalking", false);
    }
}
