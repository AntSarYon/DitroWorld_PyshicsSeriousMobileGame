using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Dialog : MonoBehaviour
{
    //Referencia al icono de Dialogo
    private GameObject iconoDialogo;

    //Flags de Estado
    private bool jugadorCerca;
    private bool dialogoIniciado;
    private int indiceLinea;

    //Tiempo que tomará typear cada caracter
    private float tiempoTipeo = 0.025f;

    //Array que almacenará las líneas de diálogo del NPC
    [SerializeField, TextArea(3,5)] private string[] lineasDialogo;

    [TextArea(3, 4)] public string ComentarioDron;

    //-----------------------------------------------------------
    
    private void Awake()
    {
        //Inicializamos flag de jugador cercano a falso
        jugadorCerca = false;

        //Obtenemos referencia al icono de excalamacion del NPC
        iconoDialogo = transform.Find("icoDialogo").gameObject;
    }

    //--------------------------------------------------------------
    //Funció para cuando se oprima el Boton de Dialogo

    public void DialogoOprimido()
    {
        //Si el jugador esta cerca, el Flag de Dialogo proximo esta Activo
        if (jugadorCerca && Manager2D.Instance.FlagDialogo)
        {
            // Si el dialogo aun no ha iniciado
            if (!dialogoIniciado)
            {
                //Iniciamos dialogo mostrando la primera linea
                IniciarDialogo();
            }
            //En caso ya haya iniciado, y se haya terminado de escribir la primera linea
            else if (UI2DController.Instance.InteractionText.text.Equals(lineasDialogo[indiceLinea]))
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
                UI2DController.Instance.InteractionText.text = lineasDialogo[indiceLinea];
            }
        }
    }

    //---------------------------------------------------------------

    private void IniciarDialogo()
    {
        //Activamos el flag de Dialogo iniciado
        dialogoIniciado = true;

        //Activamos el panel de dialogo
        UI2DController.Instance.InteractionPanel.SetActive(true);

        //Desactivamos la visualizacion del icono de dialogo
        iconoDialogo.SetActive(false);

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
        if (indiceLinea < lineasDialogo.Length)
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
        dialogoIniciado = false;

        //Desactivamos el panel de dialogo
        UI2DController.Instance.InteractionPanel.SetActive(false);

        //Volvemos a mostrar el icono de dialogo
        iconoDialogo.SetActive(true);
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
            iconoDialogo.SetActive(true);
            //Asignamos referencia a este Objeto como el propietario del Dialogo
            Manager2D.Instance.ObjetoDialogo = this.gameObject;
            //Activamos el Flag de Evento de Dialogo proximo
            Manager2D.Instance.FlagDialogo = true;
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
            iconoDialogo.SetActive(false);
            //Asignamos a null la referencia a este Objeto 
            Manager2D.Instance.ObjetoDialogo = null;
            //Desactivamos el Flag de Evento de Dialogo proximo
            Manager2D.Instance.FlagDialogo = false;
        }
    }

    //Subrutina para mostrar las lineas de dialogo con efecto de Typeo
    private IEnumerator MostrarLinea()
    {
        //Inicialmente el cuadro de texto estará vacio
        UI2DController.Instance.InteractionText.text = String.Empty;

        //Por cada caracter en la linea de diálogo
        foreach (char ch in lineasDialogo[indiceLinea])
        {
            //Incrementamos el caracter al texto mostrado
            UI2DController.Instance.InteractionText.text += ch;

            //Esperamos unas milesimas de segundo (real -> ignora la escala de tiempo seteada)
            yield return new WaitForSecondsRealtime(tiempoTipeo);
        }
    }
}
