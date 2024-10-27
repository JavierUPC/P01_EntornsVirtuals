using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molino : MonoBehaviour
{
    public float rotationSpeed = 50f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Gira el molino en el eje Z
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

}

