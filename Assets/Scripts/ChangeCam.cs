using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera cameraprimerapersona;  
    public Camera cameratercerapersona;  

    //començar amb primera persona
    private bool isFirstPerson = true;

    void Start()
    {
        //camera primera persona activa principi 
        cameraprimerapersona.gameObject.SetActive(true);
        cameratercerapersona.gameObject.SetActive(false);
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.F5))
        {
            SwitchCamera();
        }
    }

void SwitchCamera()
    {

        // Cambia estat de les camares
        //Activar desactivar camaras
       
    }

}
