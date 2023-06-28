using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Cinemachine.CinemachineFreeLook;
using System;

public class ButtonsManager : MonoBehaviour
{
    public static ButtonsManager Instance;

    //Referencia al Objeto de UI de Transicion
    private Transform objTransicion;

    //Referencia y variables para el sonido
    private AudioSource mAudioSource;

    [Header("Clips de Audio")]
    [SerializeField] private AudioClip clipAtributoSeleccionado;
    [SerializeField] private AudioClip clipCambioGravedad;
    [SerializeField] private AudioClip clipModificarParametro;
    [SerializeField] private AudioClip[] clipAplicaFuerza = new AudioClip[2];
    [SerializeField] private AudioClip[] clipsCRAB = new AudioClip[4];
    [SerializeField] private AudioClip clipPokemon;

    [Header("Referencia a Player (Camara)")]
    private GameObject CameraPlayer;

    private TouchDeteccion PlayerTouchDetection;
    private PysichsMaster PlayerPhysicsMaster;

    [SerializeField] private GameObject btnEmpujar;
    [SerializeField] private GameObject btnImpulsar;
    [SerializeField] private TextMeshProUGUI txtDescripcionFuerza;

    [Header("Objetos de UI")]
    //Lista de botones de gravedad (hijos)
    [SerializeField] private List<GameObject> optsGravedad;

    //Lista de interfaces de UI
    [SerializeField] private List<GameObject> uiMasa;
    [SerializeField] private List<GameObject> uiVelocidad;
    [SerializeField] private List<GameObject> uiFriccion;

    [Header("Textos Actualizables")]
    //Lista de Textos de propiedades f�sicas
    [SerializeField] private TextMeshProUGUI textFuerza;
    [SerializeField] private TextMeshProUGUI textMasa;
    [SerializeField] private TextMeshProUGUI textVelocidad;
    [SerializeField] private TextMeshProUGUI textFriccion;

    [Header("Objetos de UI para mostrar el OBJETIVO")]
    //Referencia a Objetos de UI para el Objetivo
    [SerializeField] private GameObject objectivePanel;
    [SerializeField] private TextMeshProUGUI objectiveText;

    [Header("Objetos de UI para la AYUDA de CRAB")]
    //Referencia a Objetos de UI para la ayuda de CRAB
    [SerializeField] private GameObject helpPanel;
    [SerializeField] private TextMeshProUGUI helpText;
    [SerializeField] private GameObject optionCRABText; //<-- Texto que deber� ocultarse

    private bool dialogoAyudaIniciado;
    private int indiceAyuda;

    //Tiempo de tipeo para paneles de texto
    private float tiempoTipeo = 0.025f;

    [Header("Objetos de UI para la AYUDA de CRAB")]
    //Referencia a Objetos de UI para los Resultados
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI actionsText;
    [SerializeField] private TextMeshProUGUI prefActionText;
    [SerializeField] private TextMeshProUGUI prefFuerzaText;
    [SerializeField] private TextMeshProUGUI maxVelText;
    [SerializeField] private TextMeshProUGUI solApoyoText;

    private float timer;

    private int contAccionesTotal;

    private bool accionGravedad0Oprimida;
    private bool accionGravedad1Oprimida;
    private bool accionGravedad2Oprimida;
    private bool accionGravedad3Oprimida;
    private bool accionGravedad4Oprimida;
    private bool accionGravedad5Oprimida;

    private bool accionEmpujeOprimida;
    private bool accionImpulsoOprimida;
    private bool accionAumentoDeMasaOprimida;
    private bool accionReduccionDeMasaOprimida;

    private int contGravedad;
    private int contModificacionDeMasa;
    private int contEmpuje;
    private int contImpulso;

    private float maxVelAlcanzada;
    private int contApoyo;


    // 3D Contabilizar� acciones y medir�...
    // EventData tendr� el Objetivo y los comentariosDeCrab

    private Event3DData dataEvento3D;

    //Flags de Status
    private bool gravedadActivada;
    private bool velocidadActivada;
    private bool masaActivada;
    private bool friccionActivada;

    public float MaxVelAlcanzada { get => maxVelAlcanzada; set => maxVelAlcanzada = value; }
    public float Timer { get => timer; set => timer = value; }
    public bool AccionGravedad0Oprimida { get => accionGravedad0Oprimida; set => accionGravedad0Oprimida = value; }
    public bool AccionGravedad1Oprimida { get => accionGravedad1Oprimida; set => accionGravedad1Oprimida = value; }
    public bool AccionGravedad2Oprimida { get => accionGravedad2Oprimida; set => accionGravedad2Oprimida = value; }
    public bool AccionGravedad3Oprimida { get => accionGravedad3Oprimida; set => accionGravedad3Oprimida = value; }
    public bool AccionGravedad4Oprimida { get => accionGravedad4Oprimida; set => accionGravedad4Oprimida = value; }
    public bool AccionGravedad5Oprimida { get => accionGravedad5Oprimida; set => accionGravedad5Oprimida = value; }
    public int ContAccionesTotal { get => contAccionesTotal; set => contAccionesTotal = value; }

    //-------------------------------------------------------

    private void Awake()
    {
        //Asignamos esta interfaz como la Instancia
        Instance = this;

        //Obtenemos referencia a la Fuente de Audio
        mAudioSource = GetComponent<AudioSource>();

        //Obtenemos referencia a la transicion
        objTransicion = transform.Find("Transition");

        //Inicializamos los Flags en Falso
        gravedadActivada = false;
        velocidadActivada = false;
        masaActivada = false;
        friccionActivada = false;

        dialogoAyudaIniciado = false;

        //Desactivamos el boton de Impulso
        btnImpulsar.SetActive(false);
        //Activamos el Boton de Empuje simple
        btnEmpujar.SetActive(true);

        //Obtenemos Data del Evento3D en turno
        dataEvento3D = GameObject.Find("Event3DData").GetComponent<Event3DData>();
    }

    //---------------------------------------------------------------------------------

    private void Start()
    {
        #region Variables de Medicion 
        //Inicializamos contadores en 0
        timer = 0.00f;

        ContAccionesTotal = 0;
        contEmpuje = 0;
        contGravedad = 0;
        contImpulso = 0;
        contModificacionDeMasa = 0;

        maxVelAlcanzada = 0;
        contApoyo = 0;

        //Inicializamos Flags de Acciones oprimidas en Falso
        accionEmpujeOprimida = false;

        AccionGravedad0Oprimida = false;
        AccionGravedad1Oprimida = false;
        AccionGravedad2Oprimida = false;
        AccionGravedad3Oprimida = false;
        AccionGravedad4Oprimida = false;
        AccionGravedad5Oprimida = false;

        accionImpulsoOprimida = false;
        accionAumentoDeMasaOprimida = false;
        accionReduccionDeMasaOprimida = false;

        #endregion

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        //Encontramos el CameraPlayer en la Escena y lo asignamos
        CameraPlayer = GameObject.Find("CameraPlayer");

        //Obtenemos referencias
        PlayerTouchDetection = CameraPlayer.GetComponent<TouchDeteccion>();
        PlayerPhysicsMaster = CameraPlayer.GetComponent<PysichsMaster>();

        //Activamos el Panel de Objetivo
        objectivePanel.SetActive(true);

        //Asignamos el Texto de Objetivo...
        objectiveText.text = dataEvento3D.TextoObjetivo;

        //Desactivamos el Panel de Objetivo
        helpPanel.SetActive(false);
    }

    //-----------------------------------------------------------------------------------------------
    #region Resultados y Adaptabilidad 
    //-----------------------------------------------------------------------------------------------

    public void MostrarPanelDeVictoria()
    {
        //Asignamos los resultados a los textos
        timeText.text = "Tiempo empleado: " + Manager3D.Instance.TiempoTranscurrido.ToString("F2") + "s";
        actionsText.text = $"Se utilizaron {ContAccionesTotal} de 10 Herramientas";
        prefActionText.text = $"Accion preferida: {ObtenerTextoDeAccionPreferida()}";
        prefFuerzaText.text = $"Tipo de Fuerza preferida: : {ObtenerTextoDeFuerzaPreferida()}";
        maxVelText.text = "Max velocidad escaneada: " + maxVelAlcanzada.ToString("F2") + "m/s";
        solApoyoText.text = $"Solicitudes de Apoyo a CRAB: {contApoyo}";

        //Mostramos el Panel de Victoria
        victoryPanel.SetActive(true);
    }

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    private string ObtenerTextoDeAccionPreferida()
    {
        int indiceMax = 0;
        int valMaximo = 0;

        string[] arrAcciones = new string[4];
        arrAcciones[0] = "EMPUJE DE OBJETOS";
        arrAcciones[1] = "IMPULSAR OBJETOS";
        arrAcciones[2] = "MODIFICAR GRAVEDAD";
        arrAcciones[3] = "MODIFICACION DE MASA";


        int[] arrContadores= new int[4];
        arrContadores[0] = contEmpuje;
        arrContadores[1] = contImpulso;
        arrContadores[2] = contGravedad;
        arrContadores[3] = contModificacionDeMasa;

        for (int i = 0; i< arrContadores.Length;i++)
        {
            if (arrContadores[i] > valMaximo)
            {
                valMaximo = arrContadores[i];
                indiceMax = i;
            }
        }

        //Regresamos un enunciado indicando la Accion y su puntaje.
        return $"{arrAcciones[indiceMax]} ({valMaximo})";
    }

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    private TipoDeAccion RegistrarAccionPreferida()
    {
        int indiceMax = 0;
        int valMaximo = 0;

        TipoDeAccion[] arrTiposAccion = new TipoDeAccion[4];
        arrTiposAccion[0] = TipoDeAccion.AccionEmpuje;
        arrTiposAccion[1] = TipoDeAccion.AccionImpulso;
        arrTiposAccion[2] = TipoDeAccion.AccionGravedad;
        arrTiposAccion[3] = TipoDeAccion.AccionMasa;

        int[] arrContadores = new int[4];
        arrContadores[0] = contEmpuje;
        arrContadores[1] = contImpulso;
        arrContadores[2] = contGravedad;
        arrContadores[3] = contModificacionDeMasa;

        for (int i = 0; i < arrContadores.Length; i++)
        {
            if (arrContadores[i] > valMaximo)
            {
                valMaximo = arrContadores[i];
                indiceMax = i;
            }
        }

        //Retornamos el Tipo de Accion mas utilizado
        return arrTiposAccion[indiceMax];
    }

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    private string ObtenerTextoDeFuerzaPreferida()
    {
        if (contEmpuje > contGravedad && contEmpuje > contImpulso)
        {
            return "EMPUJE";
        }
        else if (contGravedad > contEmpuje && contGravedad > contImpulso)
        {
            return "GRAVEDAD";
        }
        else if (contImpulso > contGravedad && contImpulso > contEmpuje)
        {
            return "IMPULSO";
        }
        else
        {
            return "SIN PREFERENCIAS";
        }
    }

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    private TipoDeFuerza ObtenerFuerzaPreferida()
    {
        if (contEmpuje > contGravedad && contEmpuje > contImpulso)
        {
            return TipoDeFuerza.Empuje;
        }
        else if (contGravedad > contEmpuje && contGravedad > contImpulso)
        {
            return TipoDeFuerza.Gravedad;
        }
        else if (contImpulso > contGravedad && contImpulso > contEmpuje)
        {
            return TipoDeFuerza.Impulso;
        }
        else
        {
            return TipoDeFuerza.SinPreferencias;
        }
    }

    //***********************************************************************

    public void EnviarResultadosAAdaptationController()
    {
        ResultadosEvento resultados = new ResultadosEvento();

        //Obtenemos la Accion y fuerza preferida
        resultados.accionFavorita = RegistrarAccionPreferida();
        resultados.fuerzaFavorita = ObtenerFuerzaPreferida();

        //Obtenemos el tiempo que hemos tardado
        resultados.tiempoFinal = CalcularTiempoDeResolucion();

        //Obtenemos la Velocidad maxima registrada en la escena
        resultados.velocidadObtenida = maxVelAlcanzada;

        //Con los datos anteriormente obtenidos, Calculamos la Dificultad de Evento percibida
        resultados.dificultadPercibida = resultados.CalcularDificultadDeEventoPercibida();

        //Agregamos el resultado a la Lista de Resultados de Evento
        GameManager.Instance.listaResultados.Add(resultados);
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    private TiempoDeResolucion CalcularTiempoDeResolucion()
    {
        if (Manager3D.Instance.TiempoTranscurrido > 0.00f && Manager3D.Instance.TiempoTranscurrido < 60.00f)
        {
            return TiempoDeResolucion.Veloz;
        }

        else if (Manager3D.Instance.TiempoTranscurrido > 60.00f && Manager3D.Instance.TiempoTranscurrido < 150.00f)
        {
            return TiempoDeResolucion.Normal;
        }

        else
        {
            return TiempoDeResolucion.Lento;
        }
    }


    //************************************************************************

    //-----------------------------------------------------------------------------------------------
    #endregion //------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------

    public void ControlarVisualizacionDeObjetivo()
    {
        if (objectivePanel.activeSelf)
        {
            objectivePanel.SetActive(false);
        }
        else if (!objectivePanel.activeSelf)
        {
            objectivePanel.SetActive(true);
        }

    }

    //------------------------------------------------------------------
    public void AyudaOprimida()
    {
        // Si el dialogo aun no ha iniciado
        if (!dialogoAyudaIniciado)
        {
            //Iniciamos dialogo
            IniciarAyuda();
        }

        //En caso ya haya iniciado, y se haya terminado de escribir la linea
        else if (helpText.text.Equals(dataEvento3D.ComentariosDron[indiceAyuda]))
        {
            //Cuando hagamos Click, Pasamos a la sigueinte linea
            TerminarAyuda();
        }
        //En caso ya haya iniciado, pero aun no se termina de escribir la linea completa
        else
        {
            //Cuando hagamos Click, Detenemos la corrutina de escritura en proceso
            StopAllCoroutines();

            ReproducirPOKEMON();

            //Mostramos la linea de dialogo completa
            helpText.text = dataEvento3D.ComentariosDron[indiceAyuda];
        }
    }
    //-------------------------------------------------------------------

    private void IniciarAyuda()
    {
        //Incrementamos el Contador de Apoyo
        contApoyo++;
        //...................................

        //Activamos el flag de Ayuda iniciada
        dialogoAyudaIniciado = true;

        //Ocultamos el texto de Ayuda Auxiliar
        optionCRABText.SetActive(false);

        ReproducirCRAB();

        //Activamos el panel de Ayuda
        helpPanel.SetActive(true);

        //Asignamos un �ndice para las ayudas del DRON.
        indiceAyuda = UnityEngine.Random.Range(0, dataEvento3D.ComentariosDron.Count);

        //Iniciamos la corrutina para tippear la linea de dialogo
        StartCoroutine(MostrarLineaAyuda());
    }

    private void TerminarAyuda()
    {
        ReproducirPOKEMON();

        //Desactivamos el flag de Dialogo iniciado
        dialogoAyudaIniciado = false;

        //Desactivamos el panel de dialogo
        helpPanel.SetActive(false);

        //Mostramos el texto de Ayuda Auxiliar
        optionCRABText.SetActive(true);
    }

    //---------------------------------------------------------------------

    //Subrutina para mostrar las lineas de dialogo con efecto de Typeo
    private IEnumerator MostrarLineaAyuda()
    {
        //Inicialmente el cuadro de texto de Ayuda estar� vacio
        helpText.text = String.Empty;

        //Por cada caracter en la linea de di�logo
        foreach (char ch in dataEvento3D.ComentariosDron[indiceAyuda])
        {
            //Incrementamos el caracter al texto mostrado
            helpText.text += ch;

            //Esperamos unas milesimas de segundo (real -> ignora la escala de tiempo seteada)
            yield return new WaitForSecondsRealtime(tiempoTipeo);
        }
    }

    //--------------------------------------------

    private void PosicionarTransicionDetras3D()
    {
        objTransicion.SetAsFirstSibling();
    }
    private void PosicionarTransicionDelante3D()
    {
        objTransicion.SetAsLastSibling();
    }


    //------------------------------------------------

    private void Update()
    {
        //Si el boton de impulso est� activo && el de Empuje est� desactivado
        if (btnImpulsar.activeSelf && !btnEmpujar.activeSelf)
        {
            //Asignamos el Texto de FUERZA DE IMPULSO a la UI
            txtDescripcionFuerza.text = "Fuerza Impulso";
        }

        //Si el boton de Empuje est� activo && el de Impulso est� desactivado
        else if (btnEmpujar.activeSelf && !btnImpulsar.activeSelf)
        {
            //Asignamos el Texto de FUERZA DE EMPUJE a la UI
            txtDescripcionFuerza.text = "Fuerza Empuje";
        }

        //Asignamos el valor de Fuerza real
        textFuerza.text = PlayerPhysicsMaster.FuerzaGolpe.ToString("F2");

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        //Si hay un RigidBody seleccionado
        if (PlayerTouchDetection.RigidBodySeleccionado != null)
        {
            textMasa.text = "Masa: " + PlayerTouchDetection.RigidBodySeleccionado.mass.ToString("F2") + " kg.";
            textVelocidad.text = "Velocidad: " + PlayerTouchDetection.RigidBodySeleccionado.velocity.magnitude.ToString("F2") + " m/s";
            textFriccion.text = "Friccion de base: " + PlayerTouchDetection.RigidBodySeleccionado.drag.ToString("F2");
        }
        //En caso no haya ningun RB seleccionado
        else
        {
            textMasa.text = "Masa: 0 kg.";
            textVelocidad.text = "Velocidad: 0 m/s";
            textFriccion.text = "Friccion: 0";
        }
    }

    //-----------------------------------------------------------------------------------------------------------------------------------

    public void CambiarModoDeFuerza()
    {
        //Si el boton de impulso est� activo && el de Empuje est� desactivado
        if (btnImpulsar.activeSelf && !btnEmpujar.activeSelf)
        {
            //Desactivamos el boton de Impulso
            btnImpulsar.SetActive(false);
            //Activamos el Boton de Empuje simple
            btnEmpujar.SetActive(true);
        }

        //Si el boton de Empuje est� activo && el de Impulso est� desactivado
        else if (btnEmpujar.activeSelf && !btnImpulsar.activeSelf)
        {
            //Activamos el Boton de Empuje simple
            btnEmpujar.SetActive(false);
            //Desactivamos el boton de Impulso
            btnImpulsar.SetActive(true);
        }
    }


    //--------------------------------------------------------------------

    private void ControlarVisualizacion(List<GameObject> ui, bool flag)
    {
        if (flag == false)
        {
            //Por cada boton de gravedad
            for (int i = 0; i < ui.Count; i++)
            {
                //Lo activamos
                ui[i].SetActive(true);
            }
            flag = true;
        }
        else if (flag )
        {
            //Caso contrario, desactivamos los botones.
            for (int i = 0; i < ui.Count; i++)
            {
                ui[i].SetActive(false);
            }
            flag = false;
        }
            
    }

    #region FuncionesJugador

    //----------------------------------------------------------------------------

    public void DetectarClickEnZonaDeInteraccion()
    {
        CameraPlayer.GetComponent<TouchDeteccion>().DetectarClickEnZonaDeInteraccion();
    }

    //-------------------------------------------------------------------------------

    public void ModificarGravedad(int direccion)
    {
        //Incrementamos el Contador de Gravedad modificada
        contGravedad++;
        //...................................

        CameraPlayer.GetComponent<PysichsMaster>().ModificarGravedad(direccion);
    }

    //--------------------------------------------------------------------------------

    public void DesacoplarseDeObjeto()
    {
        CameraPlayer.GetComponent<PysichsMaster>().DesacoplarseDeObjeto();
    }

    public void RegresarAlMedio()
    {
        CameraPlayer.GetComponent<PysichsMaster>().RegresarAlMedio();
    }

    //----------------------------------------------------------------------

    public void btnZoomInDown()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnZoomInDown();
    }
    public void btnZoomInUp()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnZoomInUp();
    }
    public void btnZoomOUTDown()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnZoomOUTDown();
    }
    public void btnZoomOUTUp()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnZoomOUTUp();
    }

    //---------------------------------------------------------------------

    public void btnRightDown()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnRightDown();
    }

    public void btnRightUp()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnRightUp();
    }

    public void btnLeftDown()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnLeftDown();
    }
    public void btnLeftUp()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnLeftUp();
    }

    public void btnUpDown()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnUpDown();
    }
    public void btnUpUp()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnUpUp();
    }

    public void btnDownDown()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnDownDown();
    }
    public void btnDownUp()
    {
        CameraPlayer.GetComponent<OrbitaController>().btnDownUp();
    }
    public void ActivarAumentoDeMasa()
    {
        CameraPlayer.GetComponent<PysichsMaster>().ActivarAumentoDeMasa();
    }

    public void DesactivarAumentoDeMasa()
    {
        //Si el aumento de Masa aun no se ha oprimido
        if (!accionAumentoDeMasaOprimida)
        {
            //Pasamos el Flag a True
            accionAumentoDeMasaOprimida = true;

            //Incrementamos el contador de acciones totales
            ContAccionesTotal++;
        }

        //Incrementamos el Contador de MasaModificada
        contModificacionDeMasa++;
        //...................................

        CameraPlayer.GetComponent<PysichsMaster>().DesactivarAumentoDeMasa();
    }

    public void ActivarReduccionDeMasa()
    {
        CameraPlayer.GetComponent<PysichsMaster>().ActivarReduccionDeMasa();
    }

    public void DesactivarReduccionDeMasa()
    {
        //Si la reduccion de Masa aun no se ha oprimido
        if (!accionReduccionDeMasaOprimida)
        {
            //Pasamos el Flag a True
            accionReduccionDeMasaOprimida = true;

            //Incrementamos el contador de acciones totales
            ContAccionesTotal++;
        }

        //Incrementamos el Contador de MasaModificada
        contModificacionDeMasa++;
        //...................................

        CameraPlayer.GetComponent<PysichsMaster>().DesactivarReduccionDeMasa();
    }

    //-------------------------------------------------------------------------------

    public void ImpulsarObjeto()
    {
        //Si la reduccion de Masa aun no se ha oprimido
        if (!accionImpulsoOprimida)
        {
            //Pasamos el Flag a True
            accionImpulsoOprimida = true;

            //Incrementamos el contador de acciones totales
            ContAccionesTotal++;
        }

        //Incrementamos el Contador de IMPULSOS
        contImpulso++;
        //...................................
        
        CameraPlayer.GetComponent<PysichsMaster>().ImpulsarObjeto();
    }

    public void Empujar()
    {
        CameraPlayer.GetComponent<PysichsMaster>().Empujar();
    }

    public void DejarDeEmpujar()
    {
        //Si la reduccion de Masa aun no se ha oprimido
        if (!accionEmpujeOprimida)
        {
            //Pasamos el Flag a True
            accionEmpujeOprimida = true;

            //Incrementamos el contador de acciones totales
            ContAccionesTotal++;
        }

        //Incrementamos el Contador de Empuje
        contEmpuje++;
        //...................................

        CameraPlayer.GetComponent<PysichsMaster>().DejarDeEmpujar();
    }

    //----------------------------------------------------------------------------------

    public void ActivarAumentoDeFuerza()
    {
        CameraPlayer.GetComponent<PysichsMaster>().ActivarAumentoDeFuerza();
    }

    public void DesactivarAumentoDeFuerza()
    {
        CameraPlayer.GetComponent<PysichsMaster>().DesactivarAumentoDeFuerza();
    }

    public void ActivarReduccionDeFuerza()
    {
        CameraPlayer.GetComponent<PysichsMaster>().ActivarReduccionDeFuerza();
    }

    public void DesactivarReduccionDeFuerza()
    {
        CameraPlayer.GetComponent<PysichsMaster>().DesactivarReduccionDeFuerza();
    }
    #endregion

    //---------------------------------------------------------------------

    public void ControlarBotonesGravedad()
    {
        ControlarVisualizacion(optsGravedad, gravedadActivada);
        gravedadActivada = !gravedadActivada;
    }
            

    public void ControlarVisualizacionDeMasa()
    {
        ControlarVisualizacion(uiMasa, masaActivada);
        masaActivada = !masaActivada;
    }

    public void ControlarVisualizacionDeFriccion()
    {
        ControlarVisualizacion(uiFriccion, friccionActivada);
        friccionActivada = !friccionActivada;
    }

    public void ControlarVisualizacionDeVelocidad()
    {
        ControlarVisualizacion(uiVelocidad, velocidadActivada);
        velocidadActivada = !velocidadActivada;
    }
    

    //------------------------------------------------------------------------------

    public void ReproducirCambioDeGravedad()
    {
        mAudioSource.PlayOneShot(clipCambioGravedad, 0.5f);
    }

    public void ReproducirUsoDeFuerza()
    {
        mAudioSource.PlayOneShot(clipAplicaFuerza[UnityEngine.Random.Range(0,2)], 0.5f);
    }

    public void ReproducirModificacionDeParametro()
    {
        mAudioSource.PlayOneShot(clipModificarParametro, 0.5f);
    }

    public void ReproducirSeleccionDeAtributo()
    {
        mAudioSource.PlayOneShot(clipAtributoSeleccionado, 0.5f);
    }

    public void ReproducirCRAB()
    {
        mAudioSource.PlayOneShot(clipsCRAB[UnityEngine.Random.Range(0,4)], 0.5f);
    }
    public void ReproducirPOKEMON()
    {
        mAudioSource.PlayOneShot(clipPokemon, 0.5f);
    }

    public void SalirDeModoCientifico()
    {
        //Regresamos a la ultima escena antes del experimento
        ScenesManager.Instance.SolicitarCambioDeEscena(ScenesManager.Instance.LastSceneName);
    }

}
