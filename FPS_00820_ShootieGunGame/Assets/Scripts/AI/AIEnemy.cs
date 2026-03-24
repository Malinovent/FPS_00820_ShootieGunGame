using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    [Header("Behaviours")]
    [SerializeField] private AIBehaviourPatrol patrolBehaviour;
    [SerializeField] private AIBehaviourChase chaseBehaviour;

    [Header("Senses")]
    [SerializeField] private AISenseHearing hearingSense;

    private AIState currentState;

    private void Start()
    {
        SetState(AIState.PATROL);

        chaseBehaviour.Initialize(navMeshAgent);

        hearingSense.onPlayerHeard += OnPlayerHeard; 
        chaseBehaviour.onTooFar += OnChaseTooFar;
        chaseBehaviour.onTooClose += OnChaseTooClose;
    }

    private void OnChaseTooClose()
    {
        //SetState(AIState.ATTACK);
    }

    private void OnChaseTooFar()
    {
        SetState(AIState.PATROL);
    }

    private void OnPlayerHeard(Transform transform)
    {
        chaseBehaviour.StartChasingTarget(transform);
        SetState(AIState.CHASE);
    }



    //On ENTER state
    private void SetState(AIState newState)
    {
        if(currentState == AIState.DIE)
            return;

        currentState = newState;

        switch (currentState)
        {
            case AIState.PATROL:
                patrolBehaviour.StartPatrol();
                break;
            case AIState.CHASE:
                break;
            case AIState.ATTACK:
                break;
            case AIState.DIE:
                break;
        }
    }

    //on UDATE state
    private void Update()
    {
        switch (currentState)
        {
            case AIState.PATROL:
                patrolBehaviour.UpdateBehaviour();
                hearingSense.UpdateHearing();
                break;
            case AIState.CHASE:
                chaseBehaviour.UpdateBehaviour();
                //What is our target?
                break;
            case AIState.ATTACK:
                break;
            case AIState.DIE:
                break;
        }
    }

    private void OnEnable()
    {
        patrolBehaviour.onNewWaypoint += SetAgentDestination;
    }

    private void OnDisable()
    {
        patrolBehaviour.onNewWaypoint -= SetAgentDestination;
    }


    private void SetAgentDestination(Transform transform)
    {
        navMeshAgent.SetDestination(transform.position);
    }

    private enum AIState
    {
        PATROL,
        CHASE,
        ATTACK,
        DIE
    }
}
