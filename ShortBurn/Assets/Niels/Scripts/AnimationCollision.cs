using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCollision : MonoBehaviour
{
    [Header("Animation Settings")]
    public Animator Animator;
    public string AnimationName;
    public string AnimationNameBack;

    [Header("Animation Info")]
    public float AnimationDuration;
    public float AnimationDurationBack;
    private AnimatorStateInfo animationState;
    private float animTime;

    private bool IsActive = false;

    void Update()
    {
        AnimationUpdater();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            IsActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            IsActive = false;
    }

    private void AnimationUpdater()
    {
        animationState = Animator.GetCurrentAnimatorStateInfo(0);
        animTime = animationState.normalizedTime;

        if (IsActive && animTime > AnimationDuration)
            Animator.Play(AnimationName);
        else if (IsActive == false && animTime > AnimationDurationBack)
            Animator.Play(AnimationNameBack);
    }
}
