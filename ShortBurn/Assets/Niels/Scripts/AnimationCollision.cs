using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCollision : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName;
    [SerializeField] private string animationNameBack;

    [Header("Animation Info")]
    [SerializeField] private float animationDuration;
    [SerializeField] private float animationDurationBack;
    private AnimatorStateInfo animationState;
    private float animTime;

    private bool IsActive = false;

    void Update()
    {
        AnimationUpdater();
    }

    // check if player is on collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ON");
            IsActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ON");
            IsActive = false;
        }
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ON");
            IsActive = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ON");
            IsActive = false;
        }
    }*/

    // wait for the animation to finish before it goes back to the default animation
    private void AnimationUpdater()
    {
        animationState = animator.GetCurrentAnimatorStateInfo(0);
        animTime = animationState.normalizedTime;

        if (IsActive && animTime > animationDuration)
            animator.Play(animationName);
        else if (IsActive == false && animTime > animationDurationBack)
            animator.Play(animationNameBack);
    }
}
