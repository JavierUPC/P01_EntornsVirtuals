using UnityEngine;

public class TentacleMovement : MonoBehaviour
{
    public float oscillationSpeed = 2.0f;  // Ajusta la velocidad de oscilaci�n
    public float oscillationAmount = 20.0f; // Amplitud de oscilaci�n (grados)

    private HingeJoint hingeJoint;
    private JointSpring jointSpring;

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        jointSpring = hingeJoint.spring;
        jointSpring.spring = 750; // Fuerza del resorte (ajusta seg�n sea necesario)
        jointSpring.damper = 5;   // Amortiguaci�n
        hingeJoint.spring = jointSpring;
        hingeJoint.useSpring = true;
    }

    void Update()
    {
        // Genera una oscilaci�n suave en el �ngulo de bisagra
        jointSpring.targetPosition = Mathf.Sin(Time.time * oscillationSpeed) * oscillationAmount;
        hingeJoint.spring = jointSpring;
    }
}
