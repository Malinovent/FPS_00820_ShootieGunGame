using System;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviourChase : MonoBehaviour
{
    [SerializeField] private float tooFarDistance = 10f;
    [SerializeField] private float tooCloseDistance = 2f;
    [SerializeField] private float chaseSpeed = 4;

    private Transform target;
    private NavMeshAgent navMeshAgent;

    public event Action onTooFar;
    public event Action onTooClose;


    public void Initialize(NavMeshAgent agent)
    {
        navMeshAgent = agent;
    }


    public void StartChasingTarget(Transform newTarget)
    {
        target = newTarget;
        navMeshAgent.speed = chaseSpeed;
    }

    public void UpdateBehaviour()
    {
        navMeshAgent?.SetDestination(target.position);

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget > tooFarDistance)
        {
            onTooFar?.Invoke();
            Debug.Log("Too far from target");
        }

        if (distanceToTarget < tooCloseDistance)
        {
            onTooClose?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, tooFarDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, tooCloseDistance);
    }
}