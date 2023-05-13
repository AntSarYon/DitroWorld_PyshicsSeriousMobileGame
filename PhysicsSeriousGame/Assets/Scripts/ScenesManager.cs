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
    private int nextSceneIndex;

    //Tiempo de espera 
    [SerializeField] private int tiempoEspera;

    //------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia al objeto de UI encargado de la transicion en la Escena
        transitionAnimator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoadedDelegate;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene escenaDescargada)
    {
        //Actualizamos los datos de la ultima escena
        lastSceneIndex = escenaDescargada.buildIndex;
        lastSceneName = escenaDescargada.name;
    }

    private void OnSceneLoadedDelegate(Scene escenaCargada, LoadSceneMode arg1)
    {
        //Actualizamos los datos de la Escena actual
        actualSceneIndex = escenaCargada.buildIndex;
        actualSceneName = escenaCargada.name;
    }

    //------------------------------------------------------

    public void SolicitarCambioDeEscena(int nextIndex, string nextName)
    {
        //Actualizamos los valores de siguiente escena
        nextSceneIndex = nextIndex;
        nextSceneName = nextName;

        //Definimos una variable para buscar el Object que contiene la transicion
        GameObject objTransition = GameObject.Find("Transition");

        //Si  encontramos la Trasición
        if (objTransition != null)
        {
            //Obtenemos referencia al objeto de UI encargado de la transicion en la Escena
            transitionAnimator = GameObject.Find("Transition").GetComponent<Animator>();

            //Cargamos la escena mientras respetamos la animación que se esta ejecutando
            StartCoroutine(CargarEscenaConAnimacion(nextSceneName));
        }

        //Caso contrario, simplemente cargamos la escena
        else CargarEscena(nextSceneName);

    }

    //-----------------------------------------------------------
    private IEnumerator CargarEscenaConAnimacion(string nombreSiguienteEscena)
    {
        //Disparamos el Trigger para reproducir animacion de FadeIn
        transitionAnimator.SetTrigger("StartTransition");

        //Esperamos a que se ejecute la animacion
        yield return new WaitForSeconds(tiempoEspera);

        //Cargamos la escena
        SceneManager.LoadScene(nombreSiguienteEscena);
    }

    //-------------------------------------------------------------
    private void CargarEscena(string nombreSiguienteEscena)
    {
        //Cargamos la escena
        SceneManager.LoadScene(nombreSiguienteEscena);

        
    }

}