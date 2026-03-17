using UnityEngine;
using System;

public class AIBehaviourPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float distanceThreshold = 1;

    public event Action<Transform> onNewWaypoint;

    private int currentWaypointIndex = 0;
    private Transform currentWaypoint;

    private void Start()
    {
        currentWaypoint = waypoints[currentWaypointIndex];
        onNewWaypoint?.Invoke(currentWaypoint);
    }

    public void UpdateBehaviour()
    {
        //If we are close to the currentwaypoint go to the next one
        float distance = Vector3.Distance(this.transform.position, currentWaypoint.position);

        if(distance <= distanceThreshold)
        {
            NextWaypoint();
        }

    }

    private void NextWaypoint()
    {
        currentWaypointIndex++;

        if(currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }

        currentWaypoint = waypoints[currentWaypointIndex];
        onNewWaypoint?.Invoke(currentWaypoint);
    }

    private void OnDrawGizmos()
    {

        for(int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);

            if(i == 0)
            {
                Gizmos.color = Color.yellow;
            }
            else
            {
                Gizmos.color = Color.red;
            }

            Gizmos.DrawSphere(waypoints[i].position, 1f);
        }

        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoints[waypoints.Length - 1].position, waypoints[0].position);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(waypoints[waypoints.Length - 1].position, 1f);
    }
}