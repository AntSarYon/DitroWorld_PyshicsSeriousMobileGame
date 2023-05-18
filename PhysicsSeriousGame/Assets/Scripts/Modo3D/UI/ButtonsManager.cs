using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject CameraPlayer;

    private TouchDeteccion PlayerTouchDetection;

    //Lista de botones de gravedad (hijos)
    [SerializeField] private List<GameObject> optsGravedad;

    [SerializeField] private TextMeshProUGUI textMasa;
    [SerializeField] private TextMeshProUGUI textVelocidad;

    //Flags de Status
    private bool gravedadActivada;

    //-------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencias
        PlayerTouchDetection = CameraPlayer.GetComponent<TouchDeteccion>();

        //Inicializamos el Flag en Falso
        gravedadActivada = false;
    }

    private void Update()
    {
        //Si hay un RigidBody seleccionado
        if (PlayerTouchDetection.RigidBodySeleccionado != null)
        {
            textMasa.text = "Masa: " + PlayerTouchDetection.RigidBodySeleccionado.mass.ToString() + " kg.";
            textVelocidad.text = "Velocidad: " + PlayerTouchDetection.RigidBodySeleccionado.velocity.magnitude.ToString("F2") + " m/s";
        }
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
