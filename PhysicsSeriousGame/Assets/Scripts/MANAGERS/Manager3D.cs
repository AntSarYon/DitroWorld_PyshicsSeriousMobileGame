using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
using System;

public class Manager3D : MonoBehaviour
{
    //Creamos referencia de instancia
    public static Manager3D Instance;

    //Flag de Victoria
    private bool victoria;
    //Flag de Evento terminado
    private bool eventoTerminado;

    //Variable de tiempo transcurrido
    private float tiempoTranscurrido;

    private AudioSource mAudioSource;


    // GETTERS Y SETTERS 
    public bool Victoria { get => victoria; set => victoria = value; }
    public float TiempoTranscurrido { get => tiempoTranscurrido; set => tiempoTranscurrido = value; }

    //---------------------------------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;

        //Obtenemos referencia a audioSource
        mAudioSource = GetComponent<AudioSource>();
        
        //Inicializamos el Flag de Evento Terminado en FALSO
        eventoTerminado = false;

    }

    //----------------------------------------------------------------------------------

    private void Start()
    {
        //Inicializamos el tiempo en 0
        tiempoTranscurrido = 0;

        //Inicializamos Flag en Falso
        victoria = false;
    }

    //---------------------------------------------------------------------------------------------------------------
    //Función encargada de ejecutarse cuando GameManager lance el Evento de OnEventAcomplished (Evento completado)
    private void EventoCompletado()
    {
        //Reproducimos sonido de Victoria
        mAudioSource.Play();

        //Llamamos al ButtonsManager para que muestre el Panel de Victoria
        ButtonsManager.Instance.MostrarPanelDeVictoria();
    }

    //---------------------------------------------------------------------------

    private void Update()
    {
        //Si el Evento aun no ha terminado...
        if (!eventoTerminado)
        {
            //Si aun no alcanzamos la victoria...
            if (!victoria)
            {
                //Incrementamos el tiempo Transcurrido en cada Frame
                tiempoTranscurrido += Time.deltaTime;
            }
            //Si ya lo logramos...
            else
            {
                //Invocamos al Evento de Juego -> Evento completado
                EventoCompletado();
                
                //Activamos el Flag de EventoTerminado para no seguir con el Bucle
                eventoTerminado=true;
            }
        }
    }


}

