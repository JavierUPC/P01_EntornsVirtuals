using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOpen : MonoBehaviour
{
    public Animator portalAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            portalAnimation.SetTrigger("open");
        }
    }
}
