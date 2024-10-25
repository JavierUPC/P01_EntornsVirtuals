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
    private Vector3 platformSpeed;

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

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);

        Vector3 direction = (targetPos - transform.position).normalized; 
        platformSpeed = direction * speed; 

        if (Vector3.Distance(transform.position, targetPos) < 0.1f) //Margen de error
        {
            currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Count;
        }

        if (onPlatform)
        {
            if (platformSpeed.y >= 0)
            {
                onPlatformRb.velocity = new Vector3(onPlatformRb.velocity.x + platformSpeed.x, onPlatformRb.velocity.y, onPlatformRb.velocity.z + platformSpeed.z);
            }
            else
            {
                onPlatformRb.velocity = new Vector3(onPlatformRb.velocity.x + platformSpeed.x, onPlatformRb.velocity.y + platformSpeed.y, onPlatformRb.velocity.z + platformSpeed.z);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        onPlatformRb = collision.rigidbody;
        onPlatform = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        onPlatform = false;
    }


    public Vector3 GetCheckpointPosition(int index)
    {
        if (index >= 0 && index < checkpoints.Count)
        {
            return checkpoints[index].position;
        }
        Debug.LogWarning("Not withing the index range"); //Para que todas las opciones tengan un return
        return Vector3.zero;
    }
}
