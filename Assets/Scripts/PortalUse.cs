using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalUse : MonoBehaviour
{
    public Transform secondTP;
    public GameObject player;
    private Transform playerTransform;
    private PortalKey portalKey;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        portalKey = player.GetComponent<PortalKey>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && portalKey.HasKey())
        {
            playerTransform.position = new Vector3(secondTP.position.x, secondTP.position.y, secondTP.position.z);
            playerTransform.rotation = Quaternion.Euler(playerTransform.rotation.x, secondTP.rotation.y, playerTransform.rotation.z);
        }
    }
}
