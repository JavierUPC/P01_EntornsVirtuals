using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform player;            // Reference to the player transform
    public float mouseSensitivity = 100f;
    public bool isFirstPersonCamera;    // True for first-person, false for third-person

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input for vertical movement (up and down)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust xRotation based on mouseY to look up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical view angle to avoid flipping

        if (isFirstPersonCamera)
        {
            // First-person: Apply rotation to the camera's local X-axis only
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        else
        {
            // Third-person: Rotate the camera up and down around the player's local X-axis
            Vector3 targetPosition = player.position;
            transform.position = targetPosition; // Keep camera centered on player
            transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y, 0f);
        }
    }
}
