using System;
using UnityEngine;
using UnityEngine.AI;

public class AIAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private float maxSpeed = 7;

    void Update()
    {
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        float forwardSpeed = navMeshAgent.velocity.magnitude;

        //normalize the forwardSpeed to be between 0 and 1
        forwardSpeed = forwardSpeed / maxSpeed;

        animator.SetFloat("forwardSpeed", forwardSpeed);
    }
}
