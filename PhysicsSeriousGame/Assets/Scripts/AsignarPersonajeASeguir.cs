using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarPersonajeASeguir : MonoBehaviour
{
    //Referencia a la Cinemachine
    private Cinemachine.CinemachineVirtualCamera cvcamera;

    //----------------------------------------------------
    private void Awake()
    {
        //Obtenemos referencia
        cvcamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    //-------------------------------------------------------

    private void Start()
    {
        //Asignamos al Player como Objeto a seguir
        cvcamera.Follow = GameObject.Find("Player").transform;
    }
}
