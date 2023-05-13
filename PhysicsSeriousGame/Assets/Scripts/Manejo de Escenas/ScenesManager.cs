using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script para controlar los cambios de Escena

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    //Referencia al Animator que controla la Transicion
    private Animator transitionAnimator;

    //Datos de la útlima Escena 
    private string lastSceneName;
    private int lastSceneIndex;

    //Datos de la Escena abierta actualmente
    private string actualSceneName;
    private int actualSceneIndex;

    //Datos de la siguiente Escena a abrir
    private string nextSceneName;

    //Tiempo de espera 
    [SerializeField] private int tiempoEspera;

    //-------------------------------------------------------------

    private void Awake()
    {
        //Controlamos la unica instancia del ScenesManager
        ControlarUnicaInstancia();
    }

    //----------------------------------------------------

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoadedDelegate;
        SceneManager.sceneUnloaded += OnSceneUnloadedDelegate;
    }

    //------------------------------------------------------

    private void OnSceneUnloadedDelegate(Scene escenaDescargada)
    {
        //Actualizamos los datos de la ultima escena
        lastSceneIndex = escenaDescargada.buildIndex;
        lastSceneName = escenaDescargada.name;
        print("La escena anterior fue " + lastSceneName);
    }

    private void OnSceneLoadedDelegate(Scene escenaCargada, LoadSceneMode arg1)
    {
        //Actualizamos los datos de la Escena actual
        actualSceneIndex = escenaCargada.buildIndex;
        actualSceneName = escenaCargada.name;
        print("La escena actual es: " + actualSceneName);
    }

    //------------------------------------------------------

    public void EmpezarJuego()
    {
        //Cargamos la escena -> El Main Menu siempre tiene animacion
        //GameObject objTransition = GameObject.Find("Transition");
        //transitionAnimator = objTransition.GetComponent<Animator>();

        //StartCoroutine(CargarEscenaConAnimacion("EM_Principal"));

        CargarEscena("EM_Principal");
    }

    //------------------------------------------------------

    public void SolicitarCambioDeEscena(string nextName)
    {
        //Actualizamos los valores de siguiente escena
        nextSceneName = nextName;

        //Definimos una variable para buscar el Object que contiene la transicion
        GameObject objTransition = GameObject.Find("Transition");

        //Si  encontramos la Trasición
        if (objTransition != null)
        {
            //Obtenemos referencia al objeto de UI encargado de la transicion en la Escena
            transitionAnimator = objTransition.GetComponent<Animator>();

            //Cargamos la escena mientras respetamos la animación que se esta ejecutando
            StartCoroutine(CargarEscenaConAnimacion(nextSceneName));
        }

        //Caso contrario, simplemente cargamos la escena
        else CargarEscena(nextSceneName);

    }

    //-----------------------------------------------------------
    public IEnumerator CargarEscenaConAnimacion(string nombreSiguienteEscena)
    {
        //Disparamos el Trigger para reproducir animacion de FadeIn
        transitionAnimator.SetTrigger("StartTransition");

        //Esperamos a que se ejecute la animacion
        yield return new WaitForSeconds(tiempoEspera);

        //Cargamos la escena
        SceneManager.LoadScene(nombreSiguienteEscena);
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