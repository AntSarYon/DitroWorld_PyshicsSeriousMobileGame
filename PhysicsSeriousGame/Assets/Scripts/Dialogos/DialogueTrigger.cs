using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;

    //------------------------------------------------------

    private void Awake()
    {
        //El VisualCue estara activo al inicio del juego
        visualCue.SetActive(false);

        //Indicamos que el jugador no esta en rango
        playerInRange = false;
    }

    //------------------------------------------------------

    private void Update()
    {
        //Controlamos que se visualice, o no, el icono de dialogo
        //dependiendo de la distnacia del PLayer, y si el Panel del
        //dialogo esta desactivado
        /*
        if (playerInRange && !DialogueManager.Instance.dialogueIsPlaying)
        {
            visualCue.SetActive(true);

            //Si se oprime el boton de interaccion
            if (InputManager.GetInstance().GetInteractPressed())
            {
                //Por ahora, mostramos el Texto del JSON
                DialogueManager.Instance.EnterDialogueMode(inkJSON);
            }
        }
        else visualCue.SetActive(false);
        */
    }

    //------------------------------------------------------

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
