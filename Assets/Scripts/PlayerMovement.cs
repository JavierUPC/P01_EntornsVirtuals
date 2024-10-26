using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject FloorChecker;
    public Animator ArmsAnimaton; // Aseg�rate de que este es el nombre correcto


    private Rigidbody rb;
    private Collider coll;
    private bool floored;

    public float moveSpeed = 6f;
    public float jumpForce = 10f;

    public float mouseSensitivity = 100f;
    private float rotationX;

    private float mouseX, moveX, moveZ;
    private float timer;
    public float runSpeed = 12f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        floored = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotationX = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);

        if (move.x != 0 || move.z != 0) // Si el personaje se est� moviendo
        {
            ArmsAnimaton.SetBool("isWalking", true); // Activar la animaci�n de caminar
        }
        else // Si el personaje est� quieto
        {
            ArmsAnimaton.SetBool("isWalking", false); // Activar la animaci�n de idle
        }


        if (!floored && !FloorChecker.GetComponent<Floored>().IsFloored()) // Si el personaje se est� moviendo
        {
            ArmsAnimaton.SetBool("isJumping", true); // Activar la animaci�n de caminar
        }
        else // Si el personaje est� quieto
        {
            ArmsAnimaton.SetBool("isJumping", false); // Activar la animaci�n de idle
        }


        //Salto - el "airtime" depende del tiempo que se mantenga el bot�n presionado
        if (floored && Input.GetKey(KeyCode.Space) && FloorChecker.GetComponent<Floored>().IsFloored())
        {
            timer += Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Space) && timer > 0 && timer <= 0.5)
        {
            timer += Time.deltaTime;
            Jump();
        }
        else if(Input.GetKeyUp(KeyCode.Space) || timer >0.5)
        {
            timer = 0;
        }

        //codigo correr
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed * runSpeed );
        }

        //Rotacion horizontal del personaje segun el movimiento del raton
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationX += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationX, 0f);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce/(1+Mathf.Pow(timer,2)), rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            floored = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            floored = false;
    }

}
