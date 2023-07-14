using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    Animator animator;
    string currentState = "Idle";

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    public void ChangeAnimationState(string stateName, float speed = 1)
    {
        animator.speed = speed;

        if (stateName == currentState)
        {
            return;
        }

        animator.Play(stateName);
        currentState = stateName;
    }
}
