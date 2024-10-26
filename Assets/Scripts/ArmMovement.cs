using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    // Referencias a los pivotes de los brazos
    public Transform leftArmPivot;
    public Transform rightArmPivot;

    public float armSwingSpeed = 2f;
    public float armSwingAmount = 15f;

    // Referencia al Rigidbody del jugador para acceder al movimiento
    public Rigidbody playerRigidbody;

    void Update()
    {
        // Obt�n la velocidad del jugador en el eje X y Z
        float moveX = playerRigidbody.velocity.x;
        float moveZ = playerRigidbody.velocity.z;

        // Si el jugador est� en movimiento, animar los brazos
        if (Mathf.Abs(moveX) > 0.1f || Mathf.Abs(moveZ) > 0.1f)
        {
            float swingAngle = Mathf.Sin(Time.time * armSwingSpeed) * armSwingAmount;
            leftArmPivot.localRotation = Quaternion.Euler(swingAngle, 0, 0);
            rightArmPivot.localRotation = Quaternion.Euler(-swingAngle, 0, 0);
        }
        else
        {
            // Regresa los brazos a su posici�n original si el jugador est� quieto
            leftArmPivot.localRotation = Quaternion.Euler(0, 0, 0);
            rightArmPivot.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
