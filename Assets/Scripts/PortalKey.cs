using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalKey : MonoBehaviour
{
    private bool switchOn;
    // Start is called before the first frame update
    void Start()
    {
        switchOn = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switchOn = true;
            gameObject.SetActive(false);
        }
    }

    public bool HasKey()
    {
        return switchOn;
    }
}
