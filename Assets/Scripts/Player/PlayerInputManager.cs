using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        // Get the PlayerMovementBehaviour script
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // On right click
        if (Input.GetMouseButtonDown(1))
        {
            playerController.HandleWorldInteraction(Input.mousePosition);
        }
    }
}
