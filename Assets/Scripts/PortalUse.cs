using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalUse : MonoBehaviour
{
    public Transform secondTP;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.position = new Vector3(secondTP.position.x, secondTP.position.y, secondTP.position.z);
            player.rotation = Quaternion.Euler(player.rotation.x, secondTP.rotation.y, player.rotation.z);
        }
    }
}
