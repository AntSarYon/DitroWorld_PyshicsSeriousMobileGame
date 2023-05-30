using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDeteccion : MonoBehaviour
{
    //Referencia al Script de Orbita
    private OrbitaController mOrbita;
    private PysichsMaster mPysichsMaster;

    //Contenedor del RigidBody del Objeto seleccionado
    private Rigidbody rigidBodySeleccionado;

    //Contenedor del RigidBody del Objeto seleccionado
    private Collider colliderSeleccionado;

    private AudioSource mAudioSource;
    [SerializeField] private AudioClip clipSeleccionDeObjeto;

    //GETTERS Y SETTERS
    public Rigidbody RigidBodySeleccionado { get => rigidBodySeleccionado; set => rigidBodySeleccionado = value; }
    public Collider ColliderSeleccionado { get => colliderSeleccionado; set => colliderSeleccionado = value; }

    //--------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia al Orbita Controller
        mOrbita = GetComponent<OrbitaController>();
        mPysichsMaster = GetComponent<PysichsMaster>();
        mAudioSource = GetComponent<AudioSource>();
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
                    //Reproducimos sonido de Seleccion de Objeto
                    mAudioSource.PlayOneShot(clipSeleccionDeObjeto, 0.5f);

                    //Hacemos que el Centro Relativo se coloque en el punto de impacto
                    mPysichsMaster.CentroRelativo.transform.position = hitClick.point; //<-- Esto no estaba

                    //Asignamos el Centro relativo como como punto de oribta
                    mOrbita.ObjetoSeguido = mPysichsMaster.CentroRelativo.transform;

                    //Hacemos que el CentroRelativo sea HIjo del Objeto Físico <-- Así lo seguirá
                    mPysichsMaster.CentroRelativo.transform.SetParent(hitClick.transform);

                    //Almacenamos el Rigidbody y Collider del Objeto Real cn el cual estamos interactuando
                    rigidBodySeleccionado = hitClick.transform.GetComponent<Rigidbody>();
                    ColliderSeleccionado = hitClick.transform.GetComponent<Collider>();

                    //De esta forma, rotaremos en base al punto que tocamos, pero el objeto físico afectado si
                    //será el que corresponda
                }
            }
        }
    }
}
