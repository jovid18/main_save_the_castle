using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutoMoveToDestination : MonoBehaviour
{
    public Transform targetDestination;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        MoveToDestination();
    }

    void MoveToDestination()
    {
        navMeshAgent.SetDestination(targetDestination.position);
    }
}