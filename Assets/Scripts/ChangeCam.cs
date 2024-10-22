using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    //asiganr en unity las camaras de primera y segunda persona
    public Camera firstPersonCamera; 
    public Camera thirdPersonCamera; 

    private void Start()
    {
        //activamos la camara en primera persona i desactivamos la tercera
        firstPersonCamera.gameObject.SetActive(true);
        thirdPersonCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        //condicional si se presiona el boton f5
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // activamos la camara pertinente si estamos en 1ra persona a 3ra y al reves
        if (firstPersonCamera.gameObject.activeSelf)
        {
            firstPersonCamera.gameObject.SetActive(false);
            thirdPersonCamera.gameObject.SetActive(true);
        }
        else
        {
            firstPersonCamera.gameObject.SetActive(true);
            thirdPersonCamera.gameObject.SetActive(false);
        }
    }
}
