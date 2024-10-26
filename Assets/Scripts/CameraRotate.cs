using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform player;             
    public float mouseSens = 100f;
    public bool isFirstPerson;     

    private float xRotation = 0f;
    private Vector3 initialPos;
    private float mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (!isFirstPerson)
        {
            initialPos = transform.position - player.position;
        }
    }

    void Update()
    {
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 
        if (isFirstPerson)
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(xRotation, player.eulerAngles.y, 0f);
            transform.position = player.position + rotation * initialPos;
            transform.LookAt(player.position + Vector3.up * 1.5f); //Por 1,5 para que enfoque ligeramente por encima de los hombros y no en el centro de la figura
        }
    }
}
