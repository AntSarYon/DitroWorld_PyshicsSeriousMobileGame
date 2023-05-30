using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineFreeLook;

public class PysichsMaster : MonoBehaviour
{
    //Distancia del rayo
    private float rangoDeteccion = 200f;

    //Referencia al Script de Orbita
    private OrbitaController mOrbita;
    private TouchDeteccion mTouchDeteccion;

    //Referencia al Objeto del medio de la escena
    [SerializeField] private GameObject centro;
    [SerializeField] private GameObject centroRelativo;

    //Fuerza para GOLPE
    private float fuerzaGolpe = 25f;
    
    //Data del objeto impactado por el Rayo
    private RaycastHit hitPointer;

    //GETTERS Y SETTERS
    public float RangoDeteccion { get => rangoDeteccion; set => rangoDeteccion = value; }
    public float FuerzaGolpe { get => fuerzaGolpe; set => fuerzaGolpe = value; }
    public GameObject Centro { get => centro; set => centro = value; }
    public GameObject CentroRelativo { get => centroRelativo; set => centroRelativo = value; }

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
        //Compruebo si hay un RigidBody asignado
        if (mTouchDeteccion.RigidBodySeleccionado != null)
        {
            //Asignamos que desde el golpe, le haremos seguimiento al Objeto en concreto
            //mOrbita.ObjetoSeguido = mTouchDeteccion.RigidBodySeleccionado.transform;

            //Disparo un rayo para obtener un punto de contacto con el objeto en la escena.
            if (Physics.Raycast(transform.position, transform.forward, out hitPointer, rangoDeteccion))
            {
                //Aplicamos la fuerza a parir del punto de contacto
                mTouchDeteccion.RigidBodySeleccionado.AddForceAtPosition(
                    (transform.forward * fuerzaGolpe),
                    hitPointer.point, 
                    ForceMode.Impulse
                    );
            }
            
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
    public void DesacoplarseDeObjeto()
    {
        //Hacemos que el Centro relativo ya no sea hijo del Objeto fisico
        centroRelativo.transform.SetParent(null);

        //Actualizamos la posicion del Centro Relativo en base al ultimo objeto seleccionado
        centroRelativo.transform.position = mOrbita.ObjetoSeguido.transform.position;

        //Cambiamos a Null la referencia de Objeto y RB seguidos
        mOrbita.ObjetoSeguido = null;
        mTouchDeteccion.RigidBodySeleccionado = null;

        //Activamos la orbita desde la posicion donde soltamos el objeto 
        mOrbita.ObjetoSeguido = centroRelativo.transform;
    }

    public void RegresarAlMedio()
    {
        //Cambiamos a Null la referencia de Objeto y RB seguidos
        mOrbita.ObjetoSeguido = null;
        mTouchDeteccion.RigidBodySeleccionado = null;

        //Lo asignamos como nuevo punto de orbita
        mOrbita.ObjetoSeguido = centro.transform;
    }

    //-------------------------------------------------------------------

    public void IncrementarFuerza()
    {
        //Solo si la fuerza es superior a 50 000..
        if (FuerzaGolpe < 50000)
        {
            //La aumentamos en 5
            FuerzaGolpe += 5;
        }
    }

    public void ReducirFuerza()
    {
        //Solo si la fuerza es superior a 0..
        if (FuerzaGolpe > 0)
        {
            //La reducimos en 5
            FuerzaGolpe -= 5;
        }

    }

    public void IncrementarMasa()
    {
        mTouchDeteccion.RigidBodySeleccionado.mass += 0.5f;
    }

    public void ReducirMasa()
    {
        mTouchDeteccion.RigidBodySeleccionado.mass -= 0.5f;

    }

    public void IncrementarFriccion()
    {
        mTouchDeteccion.RigidBodySeleccionado.drag += 0.5f;
    }

    public void ReducirFriccion()
    {
        mTouchDeteccion.RigidBodySeleccionado.drag -= 0.5f;
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
