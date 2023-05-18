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
    
    public void Empujar()
    {
        //Definimos varible que contendra la data del objeto impactado
        RaycastHit hitPointer;

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

    //--------------------------------------------------------------
    public void ModificarGravedad(int direccion)
    {
        switch (direccion)
        {
            //Caso 0 (Hacia abajo)
            case 0:
                Physics.gravity = new Vector3(0, -9.81f, 0);
                break;
            //Caso 1 (Hacia arriba)
            case 1:
                Physics.gravity = new Vector3(0, 9.81f, 0);
                break;
            //Caso 2 (Hacia la Izquierda)
            case 2:
                Physics.gravity = new Vector3(-9.81f, 0, 0);
                break;
            //Caso 3 (Hacia la Derecha)
            case 3:
                Physics.gravity = new Vector3(9.81f, 0, 0);
                break;
            //Caso 4 (Hacia Atras)
            case 4:
                Physics.gravity = new Vector3(0, 0, -9.81f);
                break;
            //Caso 5 (Hacia Adelante)
            case 5:
                Physics.gravity = new Vector3(0, 0, 9.81f);
                break;
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
