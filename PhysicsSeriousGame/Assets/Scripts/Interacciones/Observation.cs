using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observation : MonoBehaviour
{
    //Referencia al icono de Dialogo
    private GameObject iconoObservacion;

    //Referencia a Componentes
    //private AudioSource mAudioSource;
    //[SerializeField] AudioClip clipObservacion;

    //Flags de Estado
    private bool jugadorCerca;
    private bool observacionIniciada;
    private int indiceLinea;

    //Tiempo que tomará typear cada caracter
    private float tiempoTipeo = 0.025f;

    //Array que almacenará las líneas de diálogo del NPC
    [SerializeField, TextArea(4, 6)] private string[] lineasObservacion;

    //-----------------------------------------------------------

    private void Awake()
    {
        //Inicializamos flag de jugador cercano a falso
        jugadorCerca = false;

        //Referencia a componentes
        //mAudioSource = GetComponent<AudioSource>();

        //Obtenemos referencia al icono de excalamacion del NPC
        iconoObservacion = transform.Find("icoObservacion").gameObject;
    }

    //--------------------------------------------------------------
    //Funció para cuando se oprima el Boton de Dialogo

    public void ObservacionOprimida()
    {
        //Si el jugador esta cerca, el Flag de Dialogo proximo esta Activo
        if (jugadorCerca && Manager2D.Instance.FlagObservacion)
        {
            //Reproducimos el sonido de Dialogo
            //mAudioSource.PlayOneShot(clipObservacion, 0.5f);

            // Si el dialogo aun no ha iniciado
            if (!observacionIniciada)
            {
                //Iniciamos dialogo mostrando la primera linea
                IniciarDialogo();
            }
            //En caso ya haya iniciado, y se haya terminado de escribir la primera linea
            else if (UI2DController.Instance.InteractionText.text.Equals(lineasObservacion[indiceLinea]))
            {
                //Cuando hagamos Click, Pasamos a la sigueinte linea
                SiguienteLinea();
            }
            //En caso ya haya iniciado, pero aun no se termina de escribir la linea completa
            else
            {
                //Cuando hagamos Click, Detenemos la corrutina de escritura en proceso
                StopAllCoroutines();

                //Mostramos la linea de dialogo completa
                UI2DController.Instance.InteractionText.text = lineasObservacion[indiceLinea];
            }
        }
    }

    //---------------------------------------------------------------

    private void IniciarDialogo()
    {
        //Activamos el flag de Dialogo iniciado
        observacionIniciada = true;

        //Activamos el panel de dialogo
        UI2DController.Instance.InteractionPanel.SetActive(true);

        //Desactivamos la visualizacion del icono de dialogo
        iconoObservacion.SetActive(false);

        //Seteamos el indice de linea a 0 para siempre empezar
        //con la primera linea de dialogo de la lista
        indiceLinea = 0;

        //Seteamos la escala de tiempo a 0 para que todo se detenga
        Time.timeScale = 0;

        //Iniciamos la corrutina para tippear la linea de dialogo
        StartCoroutine(MostrarLinea());
    }

    //------------------------------------------------

    private void SiguienteLinea()
    {
        //Incrementamos el indice de linea de dialogo
        indiceLinea++;

        //Verificamos que la linea no exceda el limite de lineas
        if (indiceLinea < lineasObservacion.Length)
        {
            //Empezamos a mostrar la linea
            StartCoroutine(MostrarLinea());
        }
        else
        {
            //Terminamos el Dialogo
            TerminarDialogo();
        }
    }
    //-------------------------------------------------------
    private void TerminarDialogo()
    {
        //Devolvemos la escala de tiempo a la normlaidad
        Time.timeScale = 1;

        //Desactivamos el flag de Dialogo iniciado
        observacionIniciada = false;

        //Activamos el panel de dialogo
        UI2DController.Instance.InteractionPanel.SetActive(false);

        //Volvemos a mostrar el icono de dialogo
        iconoObservacion.SetActive(true);
    }

    //-----------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el jugador entra a la zona de Dialogo
        if (collision.gameObject.CompareTag("Player"))
        {
            //Activamos el Flag de jugadorCerca
            jugadorCerca = true;
            //Mostramos el icono de dialogo
            iconoObservacion.SetActive(true);
            //Asignamos referencia a este Objeto como el propietario del Dialogo
            Manager2D.Instance.ObjetoObservacion = this.gameObject;
            //Activamos el Flag de Evento de Dialogo proximo
            Manager2D.Instance.FlagObservacion = true;
        }

    }

    //-----------------------------------------------------------

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si el jugador SALE DE la zona de Dialogo
        if (collision.gameObject.CompareTag("Player"))
        {
            //Desactivamos el Flag de JugadorCerca
            jugadorCerca = false;
            //Desactivamos el icono de dialogo
            iconoObservacion.SetActive(false);
            //Cambiamos referencia a Objeto null
            Manager2D.Instance.ObjetoObservacion = null;
            //Desactivamos el Flag de Evento de Dialogo proximo
            Manager2D.Instance.FlagObservacion = false;
        }
    }

    //Subrutina para mostrar las lineas de dialogo con efecto de Typeo
    private IEnumerator MostrarLinea()
    {
        //Inicialmente el cuadro de texto estará vacio
        UI2DController.Instance.InteractionText.text = String.Empty;

        //Por cada caracter en la linea de diálogo
        foreach (char ch in lineasObservacion[indiceLinea])
        {
            //Incrementamos el caracter al texto mostrado
            UI2DController.Instance.InteractionText.text += ch;

            //Esperamos unas milesimas de segundo (real -> ignora la escala de tiempo seteada)
            yield return new WaitForSecondsRealtime(tiempoTipeo);
        }
    }
}
