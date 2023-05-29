using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDeteccion : MonoBehaviour
{
    //Referencia al Script de Orbita
    private OrbitaController mOrbita;

    //Contenedor del RigidBody del Objeto seleccionado
    private Rigidbody rigidBodySeleccionado;

    //Contenedor del RigidBody del Objeto seleccionado
    private Collider colliderSeleccionado;

    //GETTERS Y SETTERS
    public Rigidbody RigidBodySeleccionado { get => rigidBodySeleccionado; set => rigidBodySeleccionado = value; }
    public Collider ColliderSeleccionado { get => colliderSeleccionado; set => colliderSeleccionado = value; }

    //--------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia al Orbita Controller
        mOrbita = GetComponent<OrbitaController>();
    }

    //--------------------------------------------------

    private void Update()
    {
        //RAYCAST DE CLICK DE MOUSE <-- Cambiar por TOUCH más adelante

        //Si hacemos click izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            //Creamos un Ray desde el punto en que se hizo click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Creamos variable para almacenar la data del objeto impactado
            RaycastHit hitClick;

            // Usamos el rayo para hacer un RayCast en la escena - Almacenamos el resultado
            //Si es que impacta
            if (Physics.Raycast(ray, out hitClick, 200))
            {
                //Si el objeto tiene la Etiqueta de ObjetoFísico
                if (hitClick.transform.CompareTag("PhysicObject"))
                {
                    //Lo  asignamos como punto de oribta
                    mOrbita.ObjetoSeguido = hitClick.transform;

                    //Almacenamos su Rigidbody y Collider
                    rigidBodySeleccionado = hitClick.transform.GetComponent<Rigidbody>();
                    ColliderSeleccionado = hitClick.transform.GetComponent<Collider>();
                }
            }
        }
    }
}
