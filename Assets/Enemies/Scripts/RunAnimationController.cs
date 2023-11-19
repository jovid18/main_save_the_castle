using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAnimationController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = navMeshAgent.velocity.magnitude;

        if (speed > 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (navMeshAgent.remainingDistance < 0.1f && !navMeshAgent.pathPending)
        {
            animator.SetBool("IsRunning", false);
        }
    }
}