using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    public GameObject movingTarget;
    private GameObject instanceMovingTarget;

    // Components
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
            Debug.LogError("The following object has no NavMeshAgent attached : " + gameObject.name);
        else
            SetDestination();
    }

    // Method used for the NavMeshAgent to know where to go
    private void SetDestination()
    {
        if (instanceMovingTarget != null)
        {
            Vector3 targetVector = instanceMovingTarget.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
    }

    // Method used to check if the Agent is near enough an object
    public bool IsNearInteractable(float minimumDistance)
    {
        bool isNearInteractable = false;

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= minimumDistance)
            isNearInteractable = true;

        return isNearInteractable;
    }

    // Method used to spawn a moving target that the player will follow from a mouse input
    public void SpawnMovingTargetOnNavmesh(Vector3 pointPosition)
    {
        NavMeshHit closestMeshPoint;
        Vector3 targetPosition = pointPosition;

        // Vérifie si la cible est sur le navmesh
        if (NavMesh.SamplePosition(pointPosition, out closestMeshPoint, 1.0f, NavMesh.AllAreas))
            targetPosition = closestMeshPoint.position;

        navMeshAgent.stoppingDistance = 0f;
        SpawnMovingTarget(targetPosition);
    }

    public void SpawnMovingTargetNearInteractable(Vector3 interactablePosition, float stoppingDistance)
    {
        navMeshAgent.stoppingDistance = stoppingDistance;
        SpawnMovingTarget(interactablePosition);
    }

    // Method used to spawn a moving target that the player will follow from a direct position (use in cinematics)
    public void SpawnMovingTargetAtPosition(Vector3 position)
    {
        if (instanceMovingTarget != null)
            Destroy(instanceMovingTarget);

        navMeshAgent.stoppingDistance = 0f;
        SpawnMovingTarget(position);
    }

    // Methode used to spawn the moving target
    private void SpawnMovingTarget(Vector3 position)
    {
        if (instanceMovingTarget != null)
            Destroy(instanceMovingTarget);

        instanceMovingTarget = Instantiate(movingTarget, position, Quaternion.identity);
        instanceMovingTarget.name = "MovingTarget";

        SetDestination();
    }
}
