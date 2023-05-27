using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//********************************************
//Script para controlar los cambios de Escena
//*********************************************

public class ScenesManager : MonoBehaviour
{
    //Variable de Instancia unica
    public static ScenesManager Instance;

    //Referencia al Animator que controla la Transicion de una Escena
    private Animator transitionAnimator;

    //Datos de la utlima Escena 
    [HideInInspector] public string LastSceneName { get; private set; }
    [HideInInspector] public int LastSceneIndex { get; private set; }

    //Datos de la Escena abierta actualmente
    [HideInInspector] public string actualSceneName { get; private set; }
    [HideInInspector] public int actualSceneIndex { get; private set; }

    //Datos de la siguiente Escena a abrir
    [HideInInspector] public string NextSceneName { get; private set; }

    //Tiempo de espera 
    private float tiempoEspera = 1.75f;

    //-------------------------------------------------------------

    private void Awake()
    {
        //Controlamos la unica instancia del ScenesManager
        ControlarUnicaInstancia();
    }

    //----------------------------------------------------

    private void Start()
    {
        //Asignamos al SceneManager como DELEGADO de los Eventos de Escena cargada y Descargada
        SceneManager.sceneLoaded += OnSceneLoadedDelegate;
        SceneManager.sceneUnloaded += OnSceneUnloadedDelegate;
    }

    //------------------------------------------------------

    private void OnSceneUnloadedDelegate(Scene escenaDescargada)
    {
        //Actualizamos los datos de la ultima escena previa al cambio
        LastSceneIndex = escenaDescargada.buildIndex;
        LastSceneName = escenaDescargada.name;
    }

    private void OnSceneLoadedDelegate(Scene escenaCargada, LoadSceneMode arg1)
    {
        //Actualizamos los datos de la Escena actual
        actualSceneIndex = escenaCargada.buildIndex;
        actualSceneName = escenaCargada.name;
    }

    //------------------------------------------------------

    public void EmpezarJuego()
    {
        //Cargamos la Escena Inicial del Juego
        //Por ahora es el Laboratorio
        SolicitarCambioDeEscena("2DLabPrincipal");
    }

    //------------------------------------------------------

    public void SolicitarCambioDeEscena(string nextName)
    {
        //Actualizamos los valores de siguiente escena
        NextSceneName = nextName;

        //Definimos una variable para buscar el Object que contiene la transicion
        GameObject objTransition = GameObject.Find("Transition");

        //Si  encontramos la Trasicion
        if (objTransition != null)
        {
            //Colocamos el objeto de transicion al frente
            objTransition.transform.SetAsLastSibling();

            //Obtenemos referencia al Animator del Objeto UI PADRE para la transicion de la Escena
            transitionAnimator = objTransition.GetComponentInParent<Animator>();

            //Cargamos la escena mientras respetamos la animaci�n que se esta ejecutando
            StartCoroutine(CargarEscenaConAnimacion(NextSceneName));            
        }

        //Caso contrario, simplemente cargamos la escena
        else
        {
            CargarEscena(NextSceneName);
        }


    }

    //-----------------------------------------------------------
    public IEnumerator CargarEscenaConAnimacion(string nombreSiguienteEscena)
    {
        //Disparamos el Trigger para reproducir animacion de FadeIn
        transitionAnimator.SetTrigger("StartTransition");

        //Esperamos a que se ejecute la animacion (1.75 segundos)
        yield return new WaitForSeconds(tiempoEspera);

        //Cargamos la escena
        SceneManager.LoadScene(nombreSiguienteEscena);

        //Detenemos la Corutina
        StopAllCoroutines();
    }

    //-------------------------------------------------------------
    public void CargarEscena(string nombreSiguienteEscena)
    {
        //Cargamos la escena
        SceneManager.LoadScene(nombreSiguienteEscena);
    }

    //-------------------------------------------------------------
    private void ControlarUnicaInstancia()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}