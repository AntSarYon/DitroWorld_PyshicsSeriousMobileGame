using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ManipulationTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    private bool playerInRange;

    //------------------------------------------------------

    void Awake()
    {
        //El VisualCue estara activo al inicio del juego
        visualCue.SetActive(false);

        //Indicamos que el jugador no esta en rango
        playerInRange = false;
    }

    //--------------------------------------------------------------

    private void Update()
    {
        //Controlamos que se visualice, o no, el icono de dialogo
        //dependiendo de la distnacia del PLayer

        if (playerInRange)
            visualCue.SetActive(true);
        else 
            visualCue.SetActive(false);

    }

    //-----------------------------------------------------------------------------

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
