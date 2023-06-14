using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public abstract class EventsEDConditions : MonoBehaviour
{
    protected bool victoria = false;
    protected List<GameObject> listaObjetosFisicos = new List<GameObject>();

    //-----------------------------------------------------------

    public abstract void EjecutarCondicionesDeInicio();

    public abstract bool MonitorearVictoria();

    public abstract void ConfigurarObjetosFisicos();

    //-------------------------------------------------------------------------------

    // FUNCION QUE OBTIENE UNA LISTA CON TODOS LOS OBJETOS FISICOS DE AL ESCENA 3D
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
}
