using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private float y;
    public float ampli;
    public float frec;
    private float height;
    private bool x;
    private Collider player;
    private float timer;
    private float time;

    private void Start()
    {
        x = true;
        timer = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (x)
        {
            time = Time.unscaledTime;
        }
        if (!x)
        {
            timer = Time.unscaledTime - time;
            height = y + ampli * Mathf.Sin(frec * timer);
            player.transform.position = new Vector3(player.transform.position.x, height, player.transform.position.z);
            Debug.Log(Time.unscaledTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other;
        y = player.transform.position.y;
        x = false;
        player.attachedRigidbody.useGravity = false;
        Debug.Log("Dentro");
    }

    private void OnTriggerExit(Collider other)
    {
        x = true;
        Debug.Log("Fuera");
        player.attachedRigidbody.useGravity = true;
    }
}
