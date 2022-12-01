using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start() 
    {
        animator = GetComponent<Animator>();
    }
    private void Update() 
    {
        animator.speed = TimeManagerScript.TimeScale;
    }
}
