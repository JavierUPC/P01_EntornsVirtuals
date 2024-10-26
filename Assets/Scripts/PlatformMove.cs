using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Checkpoint //Lo dejo aqui fuera para que no sea exclusivamente parte de PlafromMove
{
    public Vector3 position;
}

public class PlatformMove : MonoBehaviour
{
    [Tooltip("List of checkpoints with specified coordinates.")]
    [SerializeField] private List<Checkpoint> checkpoints = new List<Checkpoint>();

    private int currentCheckpointIndex = 0;
    public float speed = 5f;
    private bool onPlatform = false;

    private Rigidbody onPlatformRb;
    private Vector3 previousPosition;  
    private Vector3 platformMovement;  

    private void Start()
    {
        previousPosition = transform.position;  
    }

    private void OnValidate()
    {
        if (checkpoints == null)
        {
            checkpoints = new List<Checkpoint>();
        }
    }

    private void FixedUpdate()
    {
        if (checkpoints.Count == 0)
            return;

        Vector3 targetPos = checkpoints[currentCheckpointIndex].position;

        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);

        platformMovement = transform.position - previousPosition;
        previousPosition = transform.position;  

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPos) < 0.1f) // Margin of error
        {
            currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Count;
        }

        if (onPlatform && onPlatformRb != null)
        {
            onPlatformRb.position += platformMovement;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)  // Check if the collided object has a Rigidbody
        {
            onPlatformRb = collision.rigidbody;
            onPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody == onPlatformRb)
        {
            onPlatform = false;
            onPlatformRb = null;  // Clear the reference to the Rigidbody
        }
    }

    public Vector3 GetCheckpointPosition(int index)
    {
        if (index >= 0 && index < checkpoints.Count)
        {
            return checkpoints[index].position;
        }
        Debug.LogWarning("Not within the index range");
        return Vector3.zero;
    }
}
