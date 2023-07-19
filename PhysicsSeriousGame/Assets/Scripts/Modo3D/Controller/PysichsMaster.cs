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
    private GameObject centro;
    private GameObject centroRelativo;

    //Fuerza para GOLPE
    [SerializeField] private float fuerzaGolpe;

    private bool incrementandoFuerza = false;
    private bool reduciendoFuerza = false;

    private bool incrementandoMasa = false;
    private bool reduciendoMasa = false;

    //Flag de Fuerza siendo aplicada
    private bool empujando = false;

    //Data del objeto impactado por el Rayo
    private RaycastHit hitPointer;

    //Variable para almacenar la maxima velocidad que obtengamos de los objetos
    private float maxVelocidadEscaneada;

    //GETTERS Y SETTERS
    public float RangoDeteccion { get => rangoDeteccion; set => rangoDeteccion = value; }
    public float FuerzaGolpe { get => fuerzaGolpe; set => fuerzaGolpe = value; }
    public GameObject Centro { get => centro; set => centro = value; }
    public GameObject CentroRelativo { get => centroRelativo; set => centroRelativo = value; }

    //------------------------------------------------------------
    void Awake()
    {
        //Obtenemos referencia a componentes
        mOrbita = GetComponent<OrbitaController>();
        mTouchDeteccion = GetComponent<TouchDeteccion>();

        //Inicializamos la Vlocidad escaneada en 0
        maxVelocidadEscaneada = 0;
    }

    private void Start()
    {
        //Obtenemos referencia a los Centros
        centro = GameObject.Find("CentroExperimento");
        centroRelativo = GameObject.Find("CentroRelativo");
    }

    //------------------------------------------------------------

    private void Update()
    {
        //Controlamos constantemente el nivel de Fuerza
        if (incrementandoFuerza){
            IncrementarFuerza();
        }

        if (reduciendoFuerza){
            ReducirFuerza();
        }

        //Controlamos contantemente el nivel de Masa del RigidBody (Si es que lo hubiera)
        if (mTouchDeteccion.RigidBodySeleccionado != null)
        {
            if (incrementandoMasa)
            {
                IncrementarMasa();
            }
            if (reduciendoMasa)
            {
                ReducirMasa();
            }

            //Si la velocidad observada por el objeto supera a la maxima ya escaneada
            if (mTouchDeteccion.RigidBodySeleccionado.velocity.magnitude > maxVelocidadEscaneada)
            {
                //Actualizamos
                maxVelocidadEscaneada = mTouchDeteccion.RigidBodySeleccionado.velocity.magnitude;
            }
        }
    }

    //------------------------------------------------------------------------------------------------------

    void FixedUpdate()
    {
        //Compruebo si hay un RigidBody asignado
        if (mTouchDeteccion.RigidBodySeleccionado != null)
        {
            //Si se esta oprimiendo el botón de EMPUJAR
            if (empujando)
            {
                //Identificamos elpunto de contacto a partir del centro de la camara hasta el Objeto
                if (Physics.Raycast(transform.position, transform.forward, out hitPointer, rangoDeteccion))
                {
                    //Aplicamos una fuerza de Empuje constante sobre ese objeto en el Punto de choque
                    //Dividimos entre la masa para que el efecto se vea afectado por la masa.

                    mTouchDeteccion.RigidBodySeleccionado.AddForceAtPosition(
                        transform.forward * fuerzaGolpe,
                        hitPointer.point,
                        ForceMode.Force
                    );
                }

            }
        }

        //Actualizamos constantemente la variable de maxima velocidad alcanzada que recibirá la interfaz;
        ButtonsManager.Instance.MaxVelAlcanzada = maxVelocidadEscaneada;
    }

    //-------------------------------------------------------------

    public void ImpulsarObjeto()
    {
        //Compruebo si hay un RigidBody asignado
        if (mTouchDeteccion.RigidBodySeleccionado != null)
        {
            //Identificamos elpunto de contacto a partir del centro de la camara hasta el Objeto
            if (Physics.Raycast(transform.position, transform.forward, out hitPointer, rangoDeteccion))
            {
                //Aplicamos una fuerza de IMPULSO ese objeto en el Punto de choque
                mTouchDeteccion.RigidBodySeleccionado.AddForceAtPosition(
                    transform.forward * fuerzaGolpe,
                    hitPointer.point,
                    ForceMode.Impulse
                );
            }
        }
    }

    public void Empujar()
    {
        //Activamos Flag de empujando
        empujando = true;
    }

    public void DejarDeEmpujar()
    {
        //Retornamos Flag de empujando de vuelta a falso
        empujando = false;
    }

    //--------------------------------------------------------------
    public void ModificarGravedad(int direccion)
    {
        switch (direccion)
        {
            //Caso 0 (Hacia abajo)
            case 0:
                //Si el boton no habia sido oprimido hasta ese momento
                if (!ButtonsManager.Instance.AccionGravedad0Oprimida)
                {
                    //Pasamos el Flag de oprimido a TRUE
                    ButtonsManager.Instance.AccionGravedad0Oprimida = true;
                    //Incrementamos el contador de acciones totales
                    ButtonsManager.Instance.ContAccionesTotal++;
                }
                Physics.gravity = new Vector3(0, -9.81f, 0);
                break;

            //Caso 1 (Hacia arriba)
            case 1:
                //Si el boton no habia sido oprimido hasta ese momento
                if (!ButtonsManager.Instance.AccionGravedad1Oprimida)
                {
                    //Pasamos el Flag de oprimido a TRUE
                    ButtonsManager.Instance.AccionGravedad1Oprimida = true;
                    //Incrementamos el contador de acciones totales
                    ButtonsManager.Instance.ContAccionesTotal++;
                }
                Physics.gravity = new Vector3(0, 9.81f, 0);
                break;

            //Caso 2 (Hacia la Izquierda)
            case 2:
                //Si el boton no habia sido oprimido hasta ese momento
                if (!ButtonsManager.Instance.AccionGravedad2Oprimida)
                {
                    //Pasamos el Flag de oprimido a TRUE
                    ButtonsManager.Instance.AccionGravedad2Oprimida = true;
                    //Incrementamos el contador de acciones totales
                    ButtonsManager.Instance.ContAccionesTotal++;
                }
                Physics.gravity = transform.right * -9.81f;
                break;

            //Caso 3 (Hacia la Derecha)
            case 3:
                //Si el boton no habia sido oprimido hasta ese momento
                if (!ButtonsManager.Instance.AccionGravedad3Oprimida)
                {
                    //Pasamos el Flag de oprimido a TRUE
                    ButtonsManager.Instance.AccionGravedad3Oprimida = true;
                    //Incrementamos el contador de acciones totales
                    ButtonsManager.Instance.ContAccionesTotal++;
                }
                Physics.gravity = transform.right * 9.81f;
                break;
            //Caso 4 (Hacia Atras)
            case 4:
                //Si el boton no habia sido oprimido hasta ese momento
                if (!ButtonsManager.Instance.AccionGravedad4Oprimida)
                {
                    //Pasamos el Flag de oprimido a TRUE
                    ButtonsManager.Instance.AccionGravedad4Oprimida = true;
                    //Incrementamos el contador de acciones totales
                    ButtonsManager.Instance.ContAccionesTotal++;
                }
                Physics.gravity = transform.forward * -9.81f;
                break;
            //Caso 5 (Hacia Adelante)
            case 5:
                //Si el boton no habia sido oprimido hasta ese momento
                if (!ButtonsManager.Instance.AccionGravedad5Oprimida)
                {
                    //Pasamos el Flag de oprimido a TRUE
                    ButtonsManager.Instance.AccionGravedad5Oprimida = true;
                    //Incrementamos el contador de acciones totales
                    ButtonsManager.Instance.ContAccionesTotal++;
                }
                Physics.gravity = transform.forward * 9.81f;
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

    //----------------------------------------------------------------------------------------

    private void IncrementarFuerza()
    {
        //Solo si la fuerza es superior a 50 000..
        if (FuerzaGolpe < 5000)
        {
            //La aumentamos en 2.5
            FuerzaGolpe += 5 * Time.deltaTime;
        }
    }

    public void ActivarAumentoDeFuerza()
    {
        incrementandoFuerza = true;
    }

    public void DesactivarAumentoDeFuerza()
    {
        incrementandoFuerza = false;
    }

    //----------------------------------------------

    private void ReducirFuerza()
    {
        //Solo si la fuerza es superior a 0..
        if (FuerzaGolpe > 0)
        {
            //La reducimos en 5
            FuerzaGolpe -= 5 * Time.deltaTime;
        }

    }

    public void ActivarReduccionDeFuerza()
    {
        reduciendoFuerza = true;
    }

    public void DesactivarReduccionDeFuerza()
    {
        reduciendoFuerza = false;
    }

    //------------------------------------------------------------------------------------------

    public void IncrementarMasa()
    {
        mTouchDeteccion.RigidBodySeleccionado.mass += 2.5f * Time.deltaTime;
    }

    public void ActivarAumentoDeMasa()
    {
        incrementandoMasa = true;
    }

    public void DesactivarAumentoDeMasa()
    {
        incrementandoMasa = false;
    }
    //------------------------------------------------------------
    public void ReducirMasa()
    {
        //Limitamos que el objeto nunca pueda pesar 0 Kg
        if (mTouchDeteccion.RigidBodySeleccionado.mass >= 0.25f)
        {
            mTouchDeteccion.RigidBodySeleccionado.mass -= 2.5f * Time.deltaTime;
        }
    }

    public void ActivarReduccionDeMasa()
    {
        reduciendoMasa = true;
    }

    public void DesactivarReduccionDeMasa()
    {
        reduciendoMasa = false;
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
