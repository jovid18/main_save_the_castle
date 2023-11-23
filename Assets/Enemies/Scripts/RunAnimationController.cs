using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAnimationController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private float deadTimer = 0f;
    private bool isDead = false;

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

        // when collided with arrow,
        if (isDead)
        {
            deadTimer += Time.deltaTime;

            // 4 seconds after collided with an arrow,
            // object will be destroyed.
            if (deadTimer >= 4f)
            {
                Debug.Log("Destroy oni");
                Destroy(gameObject);
                deadTimer = 0f;
                isDead = false; // prevent from additional calling
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("arrow"))
        {
            isDead = true;
            Debug.Log("Arrow is Collided");
            animator.SetBool("isDead", true);  
        }

    }
}