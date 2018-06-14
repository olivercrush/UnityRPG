using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Method used to handle the world interaction (interact or walk ?)
    public void HandleWorldInteraction(Vector3 mousePosition)
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if (interactedObject.tag == "Interactable")
                interactedObject.GetComponent<Interactable>().MoveToInteraction(GetComponent<MovementController>());
            else
                GetComponent<MovementController>().SpawnMovingTargetOnNavmesh(interactionInfo.point);
        }
    }
}
