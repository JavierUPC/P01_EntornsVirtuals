using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject FloorChecker;

    private Rigidbody rb;
    private Collider coll;
    private bool floored;

    public float moveSpeed = 6f;
    public float jumpForce = 10f;

    public float mouseSensitivity = 100f;
    private float rotationX;

    private float mouseX, moveX, moveZ;

    private float timer;

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

        if (floored && Input.GetKey(KeyCode.Space) && FloorChecker.GetComponent<Floored>().IsFloored())
        {
            timer += Time.deltaTime;
        }
        if ((Input.GetKeyUp(KeyCode.Space) || timer >= 1) && FloorChecker.GetComponent<Floored>().IsFloored())
        {
            Jump(timer);
            timer = 0;
        }

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationX += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationX, 0f);

        Debug.Log(FloorChecker.GetComponent<Floored>().IsFloored());
    }

    private void Jump(float tiempo)
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce+tiempo*2, rb.velocity.z);
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
