using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraInputManager : MonoBehaviour
{
    private PlayerCameraBehaviour playerCameraBehaviour;

	// Use this for initialization
	void Start ()
    {
        playerCameraBehaviour = GetComponent<PlayerCameraBehaviour>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerCameraBehaviour.ChangeCameraRotation(GetRotationInput());
        playerCameraBehaviour.ChangeCameraZoom(GetZoomInput());
	}

    // Get the rotation input
    private int GetRotationInput()
    {
        int cameraRotationDirection = 0;

        // When we press Q -> rotate camera to the left
        if (Input.GetKey(KeyCode.Q))
            cameraRotationDirection--;

        // When we press E -> rotate camera to the right
        if (Input.GetKey(KeyCode.E))
            cameraRotationDirection++;

        return cameraRotationDirection;
    }

    // Get the zoom input
    private int GetZoomInput()
    {
        int zoomDirection = 0;

        // When we scroll down -> zoom out
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            zoomDirection = -1;
        // When we scroll up -> zoom in
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            zoomDirection = 1;

        return zoomDirection;
    }
}
