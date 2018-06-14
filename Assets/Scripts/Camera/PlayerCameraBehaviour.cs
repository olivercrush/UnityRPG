using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour
{
    private GameObject player;
    private Vector3 cameraOffset;

    private int rotationDirection;
    private int zoomLevel = 0;

    public float rotationSpeed;
    public float zoomSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            Debug.LogError("The main camera can't find the player");
        else
            cameraOffset = transform.position - player.transform.position;

        transform.LookAt(player.transform);
    }

    void Update()
    {
        FollowPlayer();
    }

    // Rotate the camera based on player input from PlayerCameraInputManager.cs
    public void ChangeCameraRotation(int direction)
    {
        rotationDirection = direction;
    }

    // Zoom the camera based on player input from PlayerCameraInputManager.cs
    public void ChangeCameraZoom(int zoomDirection)
    {
        // Check that the camera will not go too close or too far
        if ((zoomDirection == -1 && zoomLevel > 0) || (zoomDirection == 1 && zoomLevel < 2))
        {
            transform.Translate(-zoomDirection * Vector3.forward * zoomSpeed);
            cameraOffset = transform.position - player.transform.position;
            zoomLevel += zoomDirection;
        }
    }

    // Follow the player based on the offset and the rotation
    private void FollowPlayer()
    {
        cameraOffset = Quaternion.AngleAxis(rotationDirection * rotationSpeed * Time.deltaTime, Vector3.up) * cameraOffset;
        transform.position = player.transform.position + cameraOffset;
        transform.LookAt(player.transform);
    }
}
