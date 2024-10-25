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

    [Tooltip("Movement speed between checkpoints.")]
    [SerializeField] private float speed = 5f;

    private int currentCheckpointIndex = 0;

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

        if (Vector3.Distance(transform.position, targetPos) < 0.1f) //Margen de error
        {
            currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Count;
        }
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
