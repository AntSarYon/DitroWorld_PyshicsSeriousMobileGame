using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    //Referencia al Objeto de UI de Transicion
    private Transform objTransicion;

    [SerializeField] private GameObject CameraPlayer;

    private TouchDeteccion PlayerTouchDetection;
    private PysichsMaster PlayerPhysicsMaster;

    //Lista de botones de gravedad (hijos)
    [SerializeField] private List<GameObject> optsGravedad;

    //Lista de interfaces de UI
    [SerializeField] private List<GameObject> uiMasa;
    [SerializeField] private List<GameObject> uiVelocidad;
    [SerializeField] private List<GameObject> uiFriccion;

    [SerializeField] private TextMeshProUGUI textFuerza;

    //Lista de Textos de propiedades físicas
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
        PlayerPhysicsMaster = CameraPlayer.GetComponent<PysichsMaster>();

        //Obtenemos referencia a la transicion
        objTransicion = transform.Find("Transition");

        //Inicializamos los Flags en Falso
        gravedadActivada = false;
        velocidadActivada = false;
        masaActivada = false;
        friccionActivada = false;
    }

    private void PosicionarTransicionDetras3D()
    {
        objTransicion.SetAsFirstSibling();
    }

    private void Update()
    {
        textFuerza.text = PlayerPhysicsMaster.FuerzaGolpe.ToString();

        //Si hay un RigidBody seleccionado
        if (PlayerTouchDetection.RigidBodySeleccionado != null)
        {
            textMasa.text = "Masa: " + PlayerTouchDetection.RigidBodySeleccionado.mass.ToString("F2") + " kg.";
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


    //--------------------------------------------------------------------

    private void ControlarVisualizacion(List<GameObject> ui, bool flag)
    {
        if (!flag)
        {
            //Por cada boton de gravedad
            for (int i = 0; i < ui.Count; i++)
            {
                //Lo activamos
                ui[i].SetActive(true);
            }
            flag = true;
        }
        else
        {
            //Caso contrario, desactivamos los botones.
            for (int i = 0; i < ui.Count; i++)
            {
                ui[i].SetActive(false);
            }
            flag = false;
        }
            
    }


    //---------------------------------------------------------------------

    public void ControlarBotonesGravedad()
    {
        ControlarVisualizacion(optsGravedad, gravedadActivada);
    }
            

    public void ControlarVisualizacionDeMasa()
    {
        ControlarVisualizacion(uiMasa, masaActivada);
    }

    public void ControlarVisualizacionDeFriccion()
    {
        ControlarVisualizacion(uiFriccion, friccionActivada);
    }

    public void ControlarVisualizacionDeVelocidad()
    {
        ControlarVisualizacion(uiVelocidad, velocidadActivada);
    }

    public void SalirDeModoCientifico()
    {
        //Regresamos a la ultima escena antes del experimento
        ScenesManager.Instance.SolicitarCambioDeEscena(ScenesManager.Instance.LastSceneName);
    }

}
