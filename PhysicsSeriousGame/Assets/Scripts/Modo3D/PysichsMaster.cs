using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineFreeLook;

public class PysichsMaster : MonoBehaviour
{
    //Distancia del rayo
    [SerializeField] float rangoDeteccion = 25f;

    //Referencia al Script de Orbita
    private OrbitaController mOrbita;
    private TouchDeteccion mTouchDeteccion;

    //Referencia al Objeto del medio de la escena
    [SerializeField] private GameObject centro;

    //Fuerza para GOLPE
    [SerializeField] private float fuerzaGolpe;

    //------------------------------------------------------------
    private void Awake()
    {
        //Obtenemos referencia a componentes
        mOrbita = GetComponent<OrbitaController>();
        mTouchDeteccion = GetComponent<TouchDeteccion>();
    }

    //------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        // RAYCAST DE PUNTERO -------

        //Definimos varible que contendra la data del objeto impactado
        RaycastHit hitPointer;

        //Si primo espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Disparo un rayo para obtener un punto de contacto con el objeto en la escena.
            if (Physics.Raycast(transform.position, transform.forward, out hitPointer, rangoDeteccion))
            {
                mTouchDeteccion.RigidBodySeleccionado.AddForceAtPosition((transform.forward * fuerzaGolpe), hitPointer.point, ForceMode.Impulse);

                //Tras Golpearlo; retiramos las referencias de Objeto y Rigidbody
                DesacoplarseDeObjeto();

                //Movemos el Centro a la posicion donde ocurrio el Golpe
                centro.transform.position = hitPointer.point;

                //Lo asignamos como nuevo punto de orbita
                mOrbita.ObjetoSeguido = centro.transform;

            }
        }
    }

    //--------------------------------------------------------------
    private void DesacoplarseDeObjeto()
    {
        mOrbita.ObjetoSeguido = null;
        mTouchDeteccion.RigidBodySeleccionado = null;
    }

    //--------------------------------------------------------------

    private void OnDrawGizmos()
    {
        //Pintaremos el rayo de color azul
        Gizmos.color = Color.blue;

        //Dibujamos el rayo hacia el frente de la camar
        Gizmos.DrawRay(transform.position, transform.forward * rangoDeteccion);
    }
}
