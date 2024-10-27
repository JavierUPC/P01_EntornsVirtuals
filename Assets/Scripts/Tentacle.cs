using UnityEngine;

public class TentacleMovement : MonoBehaviour
{
    public float oscillationSpeed = 2.0f;  // Ajusta la velocidad de oscilación
    public float oscillationAmount = 20.0f; // Amplitud de oscilación (grados)

    private HingeJoint hingeJoint;
    private JointSpring jointSpring;

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        jointSpring = hingeJoint.spring;
        jointSpring.spring = 750; // Fuerza del resorte (ajusta según sea necesario)
        jointSpring.damper = 5;   // Amortiguación
        hingeJoint.spring = jointSpring;
        hingeJoint.useSpring = true;
    }

    void Update()
    {
        // Genera una oscilación suave en el ángulo de bisagra
        jointSpring.targetPosition = Mathf.Sin(Time.time * oscillationSpeed) * oscillationAmount;
        hingeJoint.spring = jointSpring;
    }
}
