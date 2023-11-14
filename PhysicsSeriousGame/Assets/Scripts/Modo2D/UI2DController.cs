using System;
using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI2DController : MonoBehaviour
{
    //Variable de Instancia
    public static UI2DController Instance;

    //Referencia a Componentes de Audio
    private AudioSource mAudioSource;
    [SerializeField] AudioClip clipClicks;
    [SerializeField] AudioClip clipManipulacion;
    [SerializeField] AudioClip clipEvento3D;
    [SerializeField] AudioClip[] clipsDron = new AudioClip[5];

    //Referencia a Botones de Accion
    [SerializeField] private GameObject[] botonesInteraccion = new GameObject[5];

    //Referencia al Objeto de UI de Transicion
    private Transform objTransicion;

    //Referencia a Objetos de UI para la ineraccion
    [SerializeField] private GameObject interactionPanel;
    [SerializeField] private TextMeshProUGUI interactionText;

    //Referencia a Objetos de UI para el STATUS
    [SerializeField] private GameObject dataPanel;

    [SerializeField] private TextMeshProUGUI dificultadText;
    [SerializeField] private TextMeshProUGUI impulsosText;
    [SerializeField] private TextMeshProUGUI empujesText;
    [SerializeField] private TextMeshProUGUI gravedadText;
    [SerializeField] private TextMeshProUGUI masaText;
    [SerializeField] private TextMeshProUGUI solicitudesText;
    [SerializeField] private TextMeshProUGUI tiempoText;
    [SerializeField] private TextMeshProUGUI ultimoDesafio;

    private bool mostrandoPromedio = false;


    public GameObject InteractionPanel { get => interactionPanel; set => interactionPanel = value; }
    public TextMeshProUGUI InteractionText { get => interactionText; set => interactionText = value; }

    //-----------------------------------------------------

    private void Awake()
    {
        //Asignamos instancia
        Instance = this;

        //Obtenemos referencia al AudioSource
        mAudioSource = GetComponent<AudioSource>();

        //Obtenemos referencia a la transicion
        objTransicion = transform.Find("Transition");
    }

    //---------------------------------------------------------

    public void MostrarSoloBotonEnCurso(string nombreObjetoBoton)
    {
        //Por cada boton en Botones Interaccion
        foreach (GameObject btn in botonesInteraccion)
        {
            //Si el nombre del Boton no es el mismo que el de entrada
            if (btn.gameObject.name != nombreObjetoBoton)
            {
                //Desactivamos el Boton
                btn.SetActive(false);
            }
        }

    }

    public void MostraTodosLosBotones()
    {
        //Por cada boton en Botones Interaccion
        foreach (GameObject btn in botonesInteraccion)
        {
                //Activamos el Boton
                btn.SetActive(true);
        }

    }

    //-----------------------------------------------------------------------------
    //------------------------------------------------------------------------------

    public void MostrarDataDeJuego()
    {
        mAudioSource.PlayOneShot(clipClicks, 0.5f);

        //Asignamos los Parametros
        if (GameManager.Instance.listaResultados.Count == 0)
        {
            dificultadText.text = "Aun no se han completado Eventos";
        }
        else
        {
            dificultadText.text = "Dificultad percibida en ultimo evento: " + GameManager.Instance.listaResultados[GameManager.Instance.listaResultados.Count - 1].dificultadPercibida;
        }
        impulsosText.text = "Impulsos realizados: " + GameManager.Instance.contAccionImpulso;
        empujesText.text = "Empujes realizados: " + GameManager.Instance.contAccionEmpuje;
        gravedadText.text = "Cambios de Gravedad: " + GameManager.Instance.contAccionGravedad;
        masaText.text = "Alteraciones de Masa: " + GameManager.Instance.contAccionMasa;
        solicitudesText.text = "Solicitudes de Apoyo a CRAB: " + GameManager.Instance.numSolicitudesActuales;
        tiempoText.text = "Tiempo de resolucion Promedio: " + GameManager.Instance.tiempoDeResolucionPromedio.ToString("F2") + "s";
        ultimoDesafio.text = "Dificultad del Juego Actual: " + GameManager.Instance.siguienteDificultad;

        mostrandoPromedio = false;

        //Activamos el Panel de Data
        dataPanel.SetActive(true);
    }

    public void AlternarParametros()
    {
        mAudioSource.PlayOneShot(clipClicks, 0.5f);

        if (!mostrandoPromedio)
        {
            //Asignamos los Parametros
            dificultadText.text = "DATOS PROMEDIO POR EVENTO";
            impulsosText.text = "Impulsos por evento: " + GameManager.Instance.avgAccionImpulso;
            empujesText.text = "Empujes por evento: " + GameManager.Instance.avgAccionEmpuje;
            gravedadText.text = "Cambios de Gravedad por evento: " + GameManager.Instance.avgAccionGravedad;
            masaText.text = "Cambios de Masa por evento: " + GameManager.Instance.avgAccionMasa;
            solicitudesText.text = "Solicitudes por evento: " + GameManager.Instance.avgSolicitudes;
            tiempoText.text = "Accion favorita: " + GameManager.Instance.accionFavoritaActual;
            ultimoDesafio.text = "Dificultad del Juego Actual: " + GameManager.Instance.siguienteDificultad;

            mostrandoPromedio = true;
        }
        else
        {
            //Asignamos los Parametros
            if (GameManager.Instance.listaResultados.Count == 0)
            {
                dificultadText.text = "Aun no se han completado Eventos";
            }
            else
            {
                dificultadText.text = "Dificultad percibida en ultimo evento: " + GameManager.Instance.listaResultados[GameManager.Instance.listaResultados.Count - 1].dificultadPercibida;
            }
            impulsosText.text = "Impulsos realizados: " + GameManager.Instance.contAccionImpulso;
            empujesText.text = "Empujes realizados: " + GameManager.Instance.contAccionEmpuje;
            gravedadText.text = "Cambios de Gravedad: " + GameManager.Instance.contAccionGravedad;
            masaText.text = "Alteraciones de Masa: " + GameManager.Instance.contAccionMasa;
            solicitudesText.text = "Solicitudes de Apoyo a CRAB: " + GameManager.Instance.numSolicitudesActuales;
            tiempoText.text = "Tiempo de resolucion Promedio: " + GameManager.Instance.tiempoDeResolucionPromedio.ToString("F2") + "s";
            ultimoDesafio.text = "Dificultad del Juego Actual: " + GameManager.Instance.siguienteDificultad;
            
            mostrandoPromedio = false;
        }
        
    }

    public void OcultarDataDeJuego()
    {
        mAudioSource.PlayOneShot(clipClicks, 0.5f);

        //Desactivamos el Panel de Data
        dataPanel.SetActive(false);
    }

    //-----------------------------------------------------------------------------
    //------------------------------------------------------------------------------

    private void PosicionarTransicionDetras()
    {
        objTransicion.SetAsFirstSibling();
    }

    //---------------------------------------------------------

    private void PosicionarTransicionDelante()
    {
        objTransicion.SetAsLastSibling();
    }

    //---------------------------------------------------------

    //---------------------------------------------------------

    public void MoverArriba()
    {
        Manager2D.Instance.MoveInput = Vector3.up;
    }

    public void MoverAbajo()
    {
        Manager2D.Instance.MoveInput = Vector3.down;
    }

    public void MoverIzquierda()
    {
        Manager2D.Instance.MoveInput = Vector3.left;
    }

    public void MoverDerecha()
    {
        Manager2D.Instance.MoveInput = Vector3.right;
    }

    public void Detenerse()
    {
        Manager2D.Instance.MoveInput = Vector3.zero;
    }

    public void BtnDialogClick()
    {
        if (Manager2D.Instance.ObjetoDialogo != null)
        {
            //Llamamos a la funcion de DialogoOprimido desde el Objeto dueño del dialogo
            Manager2D.Instance.ObjetoDialogo.GetComponent<Dialog>().DialogoOprimido();
            //Reproducimos Sonido de Pokemon
            mAudioSource.PlayOneShot(clipClicks, 0.5f);
        }
    }

    public void BtnObservationClick()
    {
        if (Manager2D.Instance.ObjetoObservacion != null)
        {
            //Llamamos a la funcion de DialogoOprimido desde el Objeto dueño del dialogo
            Manager2D.Instance.ObjetoObservacion.GetComponent<Observation>().ObservacionOprimida();
            ////Reproducimos Sonido de Pokemon
            mAudioSource.PlayOneShot(clipClicks, 0.5f);
        }
    }

    //-------------------------------------------------------------------------------------------------------
    public void BtnManipulationClick()
    {
        if (Manager2D.Instance.ObjetoManipulacion != null)
        {
            //Reproducimos Sonido de Manipulacion
            mAudioSource.PlayOneShot(clipManipulacion, 0.5f);
        }
    }

    public void BtnManipulationDown()
    {
        if (Manager2D.Instance.ObjetoManipulacion != null)
        {
            //Llamamos a la funcion de ManipulacionOprimida desde el Objeto dueño del dialogo
            //Manager2D.Instance.ObjetoManipulacion.GetComponent<Manipulation>().ManipulacionOprimida();
        }
    }

    public void BtnManipulationUp()
    {
        if (Manager2D.Instance.ObjetoManipulacion != null)
        {
            //Llamamos a la funcion de Convertir a Kinematico
            Manager2D.Instance.ObjetoManipulacion.GetComponent<Manipulation>().ConvertirAKinematico();
        }
    }

    //--------------------------------------------------------------------------------------------------------


    public void BtnComentarioDronClick()
    {
        //Si el Dron aun no ha mepezado a hablar
        if (!Manager2D.Instance.Dron.GetComponent<DronCommentsController>().DronEmpezoAHablar)
        {
            //Reproducimos sonido del Dron e invocamos a la funcion
            mAudioSource.PlayOneShot(clipsDron[UnityEngine.Random.Range(0, 5)], 0.5f);
            Manager2D.Instance.Dron.GetComponent<DronCommentsController>().BtnComentarioDronOprimido();
        }
        else
        {
            //Reproducimos sonido de Click(Pokemon) e invocamos a la funcion
            mAudioSource.PlayOneShot(clipClicks, 0.5f);
            Manager2D.Instance.Dron.GetComponent<DronCommentsController>().BtnComentarioDronOprimido();
        }
    }




    //----------------------------------------------------------------------------------------------------------

    public void BtnEvento3DClick()
    {
        if (Manager2D.Instance.ObjetoEvento3D != null)
        {
            mAudioSource.PlayOneShot(clipEvento3D, 0.5f);
            //Manager2D.Instance.ObjetoEvento3D.GetComponent<Event3D>().BtnEvento3DOprimido();
        }
    }

    //---------------------------------------------------------------
    //---------------------------------------------------------------

    public void VolverAlMenu()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("MainMenu");
    }
}
