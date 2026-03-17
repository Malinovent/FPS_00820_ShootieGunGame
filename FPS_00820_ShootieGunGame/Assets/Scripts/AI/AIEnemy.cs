using System;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private AIBehaviourPatrol patrolBehaviour;

    //FOR DEBUGGING
    //[SerializeField] private Transform destination;

    private void OnEnable()
    {
        patrolBehaviour.onNewWaypoint += SetAgentDestination;
    }

    private void OnDisable()
    {
        patrolBehaviour.onNewWaypoint -= SetAgentDestination;
    }

    private void Update()
    {
        //navMeshAgent.SetDestination(destination.position);

        patrolBehaviour.UpdateBehaviour();
    }

    private void SetAgentDestination(Transform transform)
    {
        navMeshAgent.SetDestination(transform.position);
    }
}
