using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 point;

    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = point;
        }
    }
}
