using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    private Vector3 initPos, initPos2;
    private Rigidbody rb;
    public Rigidbody otherPlatformrb;
    public Transform otherPlatform;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPos2 = otherPlatform.position;
        initPos = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (otherPlatform.position.y > initPos.y -50)
        {
            rb.velocity = new Vector3(0, -otherPlatformrb.velocity.y, 0);
        }
        else
        {
            otherPlatformrb.velocity = new Vector3(0,0,0);
            transform.position = initPos;
            otherPlatform.position = initPos2;
        }
    }
}
