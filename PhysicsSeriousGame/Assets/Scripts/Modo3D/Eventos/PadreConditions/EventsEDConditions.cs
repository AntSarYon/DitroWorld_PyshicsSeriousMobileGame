using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public abstract class EventsEDConditions : MonoBehaviour
{
    //Lista de Objetos Fisicos dentro del nivel [heredados por cada Evento3D]
    protected List<GameObject> listaObjetosFisicos = new List<GameObject>();

    //------------------------------------------------------------------
    //Función donde se definicran las condiciones de inicio del Evento
    public abstract void EjecutarCondicionesDeInicio();

    //-----------------------------------------------------------
    //Funcion donde se definirá la condición que lleva a la Victoria
    public abstract bool MonitorearVictoria();

    //--------------------------------------------------------------------------------------
    //Función donde se definirá la configuración de los objetos fisicos al empezar el Evento

    public abstract void ConfigurarObjetosFisicos();


    //--------------------------------------------------------------------------------------
    // FUNCION YA DEFINIDA - OBTIENE UNA LISTA CON TODOS LOS OBJETOS FISICOS DE LA ESCENA 3D
    public void ObtenerObjetosFisicos()
    {
        Transform[] listaTransformsObjetosFisicos = GameObject.Find("ObjetosExperimento").GetComponentsInChildren<Transform>();

        if (listaTransformsObjetosFisicos != null)
        {
            foreach (Transform t in listaTransformsObjetosFisicos)
            {
                if (t != null && t.gameObject != null && t.CompareTag("PhysicObject"))
                    listaObjetosFisicos.Add(t.gameObject);
            }
        }
    }

    //-----------------------------------------------------------------
    //START que sera ejecutado por todos sus hijos 

    protected virtual void Start()
    {
        //Obtenemos Lista con los Objetos fisicos del Escenario
        ObtenerObjetosFisicos();

        ConfigurarObjetosFisicos();

        //Ejecutamos las condiciones de inicio del Evento3D
        EjecutarCondicionesDeInicio();
    }

    //-------------------------------------------------------------------
    //UPDATE que sera ejecutado por todos sus hijos 

    protected virtual void Update()
    {
        //Monitoreamos la Victoria constantemente -> arroja BOOL
        Manager3D.Instance.Victoria = MonitorearVictoria();
    }
}
