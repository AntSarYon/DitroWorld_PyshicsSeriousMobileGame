using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Event3D : MonoBehaviour
{
    public int IDEvento;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    private AudioSource mAudioSource;

    private bool playerInRange;

    [SerializeField] private string nombreEscena3D;
    public string NombreEscena3D { get => nombreEscena3D; set => nombreEscena3D = value; }

    //-------------------------------------------------------------
    private void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();

        //El VisualCue estara activo al inicio del juego
        visualCue.SetActive(false);

        //Indicamos que el jugador no esta en rango
        playerInRange = false;
    }

    //---------------------------------------------------------------------------------

    private void Update()
    {
        //Controlamos que se visualice, o no, el icono de EVENTO 
        //dependiendo de la distnacia del PLayer, y si el Panel del
        //dialogo esta desactivado

        if (playerInRange && !DialogueManager.Instance.dialogueIsPlaying)
        {
            visualCue.SetActive(true);

            //Si se oprime el boton de interaccion
            if (InputManager.Instance.GetSubmitPressed())
            {
                //Reproducimos el sonido de ingresar a Evento 3D
                mAudioSource.Play();

                //Solicitamos el cambio de Escena.
                ScenesManager.Instance.SolicitarCambioDeEscena(NombreEscena3D);
            }

        }
        else visualCue.SetActive(false);
    }

    //---------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el Objeto colisionado tiene la etiqueta de PLAYER -> Activamos Flag
        playerInRange = collision.gameObject.CompareTag("Player") ? true : false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si el Objeto colisionado tiene la etiqueta de PLAYER -> Desactivamos flag
        playerInRange = collision.gameObject.CompareTag("Player") ? false : true;
    }
}
