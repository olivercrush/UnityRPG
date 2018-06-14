using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    public float stoppingDistance;
    private MovementController currentMovementController;
    private bool hasInteracted;

    public virtual void ShowInteractions()
    {

    }

    public virtual void MoveToInteraction(MovementController movementController)
    {
        hasInteracted = false;
        currentMovementController = movementController;
        currentMovementController.SpawnMovingTargetNearInteractable(transform.position, stoppingDistance);
    }

    private void Update()
    {
        if (currentMovementController != null && currentMovementController.IsNearInteractable(stoppingDistance))
        {
            if (!hasInteracted)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
