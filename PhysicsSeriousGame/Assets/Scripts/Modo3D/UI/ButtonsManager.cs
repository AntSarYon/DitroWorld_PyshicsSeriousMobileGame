using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    //Lista de botones de gravedad (hijos)
    [SerializeField] private List<GameObject> optsGravedad;

    //Flags de Status
    private bool gravedadActivada;

    //-------------------------------------------------------

    private void Awake()
    {
        //Inicializamos el Flag en Falso
        gravedadActivada = false;
    }

    public void ControlarBotonesGravedad()
    {
        //Si la opcion de gravedad no esta activada
        if (!gravedadActivada)
        {
            //Por cada boton de gravedad
            for (int i = 0; i < optsGravedad.Count; i++)
            {
                //Lo activamos
                optsGravedad[i].SetActive(true);
            }

            //Activamos el Flag
            gravedadActivada = true;
        }
        else
        {
            //Caso contrario, desactivamos los botones.
            for (int i = 0; i < optsGravedad.Count; i++)
            {
                optsGravedad[i].SetActive(false);
            }
            //Deesactivamos el Flag
            gravedadActivada = false;
        }
    }
}
