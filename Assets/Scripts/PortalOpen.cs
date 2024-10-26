using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOpen : MonoBehaviour
{
    public Animator portalAnimation;
    public GameObject Switch;
    private PortalKey portalKey;

    // Start is called before the first frame update
    void Start()
    {
        portalKey = Switch.GetComponent<PortalKey>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && portalKey.HasKey())
        {
            portalAnimation.SetTrigger("open");
        }
    }
}
