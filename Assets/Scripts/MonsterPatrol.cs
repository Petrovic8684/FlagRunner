using UnityEngine;
using UnityEngine.AI;

public class MonsterPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float rotationSpeed = 5f;

    private NavMeshAgent agent;
    private int currentWaypointIndex;

    private void Awake()
    {
        if (!TryGetComponent(out agent) || waypoints == null || waypoints.Length == 0)
        {
            enabled = false;
            return;
        }

        agent.updateRotation = false;

        currentWaypointIndex = 0;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    private void Update()
    {
        RotateTowardsDestination();

        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance) return;

        GoToNextWaypoint();
    }

    private void RotateTowardsDestination()
    {
        Vector3 direction = agent.steeringTarget - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude < 0.01f) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void GoToNextWaypoint()
    {
        currentWaypointIndex++;

        if (currentWaypointIndex >= waypoints.Length)
            currentWaypointIndex = 0;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
