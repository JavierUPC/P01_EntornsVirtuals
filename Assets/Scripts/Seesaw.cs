using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody otherPlatform;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, -otherPlatform.velocity.y, 0);
    }
}
