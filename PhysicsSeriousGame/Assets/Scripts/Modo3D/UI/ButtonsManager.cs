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

    [SerializeField] private List<GameObject> uiMasa;
    [SerializeField] private List<GameObject> uiVelocidad;
    [SerializeField] private List<GameObject> uiFriccion;
    

    [SerializeField] private TextMeshProUGUI textMasa;
    [SerializeField] private TextMeshProUGUI textVelocidad;
    [SerializeField] private TextMeshProUGUI textFriccion;

    //Flags de Status
    private bool gravedadActivada;
    private bool velocidadActivada;
    private bool masaActivada;
    private bool friccionActivada;

    //-------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencias
        PlayerTouchDetection = CameraPlayer.GetComponent<TouchDeteccion>();

        //Inicializamos los Flags en Falso
        gravedadActivada = false;
        velocidadActivada = false;
        masaActivada = false;
        friccionActivada = false;
    }

    private void Update()
    {
        //Si hay un RigidBody seleccionado
        if (PlayerTouchDetection.RigidBodySeleccionado != null)
        {
            textMasa.text = "Masa: " + PlayerTouchDetection.RigidBodySeleccionado.mass.ToString() + " kg.";
            textVelocidad.text = "Velocidad: " + PlayerTouchDetection.RigidBodySeleccionado.velocity.magnitude.ToString("F2") + " m/s";
            textFriccion.text = "Friccion: " + PlayerTouchDetection.RigidBodySeleccionado.drag.ToString("F2");
        }
        //En caso no haya ningun RB seleccionado
        else
        {
            textMasa.text = "Masa: 0 kg.";
            textVelocidad.text = "Velocidad: 0 m/s";
            textFriccion.text = "Friccion: 0";
        }
    }



    private void ActivarVisualizacion(List<GameObject> ui)
    {
            //Por cada boton de gravedad
            for (int i = 0; i < ui.Count; i++)
            {
                //Lo activamos
                ui[i].SetActive(true);
            }
    }

    private void DesactivarVisualizacion(List<GameObject> ui)
    {
            //Caso contrario, desactivamos los botones.
            for (int i = 0; i < ui.Count; i++)
            {
                ui[i].SetActive(false);
            }
    }


    //---------------------------------------------------------------------

    public void ControlarBotonesGravedad()
    {
        if (!gravedadActivada)
        {
            ActivarVisualizacion(optsGravedad);
            gravedadActivada=true;
        }
        else
        {
            DesactivarVisualizacion(optsGravedad);
            gravedadActivada = false;
        }
    }
            

    public void ControlarVisualizacionDeMasa()
    {
        if (!masaActivada)
        {
            ActivarVisualizacion(uiMasa);
            masaActivada = true;
        }
        else
        {
            DesactivarVisualizacion(uiMasa);
            masaActivada = false;
        }
    }

    public void ControlarVisualizacionDeFriccion()
    {
        if (!friccionActivada)
        {
            ActivarVisualizacion(uiFriccion);
            friccionActivada = true;
        }
        else
        {
            DesactivarVisualizacion(uiFriccion);
            friccionActivada = false;
        }
    }

    public void ControlarVisualizacionDeVelocidad()
    {
        if (!velocidadActivada)
        {
            ActivarVisualizacion(uiVelocidad);
            velocidadActivada = true;
        }
        else
        {
            DesactivarVisualizacion(uiVelocidad);
            velocidadActivada = false;
        }
    }

}
