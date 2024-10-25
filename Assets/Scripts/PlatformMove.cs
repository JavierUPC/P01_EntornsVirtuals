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
    public bool onPlatform = false;

    private Rigidbody onPlatformRb;
    private Rigidbody platformRb;

    private void Start()
    {
        platformRb = GetComponent<Rigidbody>();
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

        Vector3 direction = (targetPos - transform.position).normalized;

        Vector3 desiredVelocity = direction * speed;

        platformRb.velocity = new Vector3(desiredVelocity.x, platformRb.velocity.y, desiredVelocity.z);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f) // Margin of error
        {
            currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Count;
        }

        if (onPlatform)
        {
            onPlatformRb.velocity = new Vector3(onPlatformRb.velocity.x + platformRb.velocity.x, onPlatformRb.velocity.y, onPlatformRb.velocity.z + platformRb.velocity.z);
        }

        Debug.Log(platformRb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        onPlatformRb = collision.rigidbody;
        onPlatform = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody == onPlatformRb)
        {
            onPlatform = false;
            onPlatformRb = null;
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
