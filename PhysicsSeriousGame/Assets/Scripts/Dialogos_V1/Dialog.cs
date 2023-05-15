using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Dialog : MonoBehaviour
{
    //Referencia al icono de exclamacion
    private GameObject iconoDialogo;

    //Flags de Estado
    private bool jugadorCerca;
    private bool dialogoIniciado;
    private int indiceLinea;

    //Tiempo que tomará typear cada caracter
    private float tiempoTipeo = 0.025f;

    //Array que almacenará las líneas de diálogo del NPC
    [SerializeField, TextArea(4,6)] private string[] lineasDialogo;

    //Referencia a objetos de interfazGrafica para el dialogo
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;

    //-----------------------------------------------------------
    
    private void Awake()
    {
        //Inicializamos flag de jugador cercano a falso
        jugadorCerca = false;

        //Obtenemos referencia al icono de excalamacion del NPC
        iconoDialogo = transform.Find("Exclamation").gameObject;
    }

    //-----------------------------------------------------------
    
    void Update()
    {
        //Si el jugador esta cerca, y oprimimos ESPACIO <-- CONFIGURAR DESPUES
        if (jugadorCerca && Input.GetKeyDown(KeyCode.Space))
        {
            //Si el dialogo aun no se ha iniciado
            if (!dialogoIniciado)
            {
                //Iniciamos dialogo mostrando la primera linea
                IniciarDialogo();
            }
            //En caso ya haya iniciado, y se haya terminado de escribir la primera linea
            else if (dialogText.text.Equals(lineasDialogo[indiceLinea]))
            {
                //Pasamos a la sigueinte linea
                SiguienteLinea();
            }
            //En caso ya haya iniciado, pero aun no se termina de escribir la linea completa
            else
            {
                //Detenemos la corrutina de escritura en proceso
                StopAllCoroutines();

                //Mostramos la linea de dialogo completa
                dialogText.text = lineasDialogo[indiceLinea];
            }
        }
    }

    //--------------------------------------------------------------

    private void IniciarDialogo()
    {
        //Activamos el flag de Dialogo iniciado
        dialogoIniciado = true;

        //Activamos el panel de dialogo
        dialogPanel.SetActive(true);

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
            StartCoroutine(MostrarLinea());
        }
        else
        {
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

        //Activamos el panel de dialogo
        dialogPanel.SetActive(false);

        //Volvemos a mostrar el icono de dialogo
        iconoDialogo.SetActive(true);
    }

    //-----------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Activamos el Flag y mostramos el icono de dialogo
            jugadorCerca = true;
            iconoDialogo.SetActive(true);            
        }

    }

    //-----------------------------------------------------------

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Activamos tanto el Flag como el icono de dialogo
            jugadorCerca = false;
            iconoDialogo.SetActive(false);
        }
    }

    //Subrutina para mostrar las lineas de dialogo con efecto de Typeo
    private IEnumerator MostrarLinea()
    {
        //Inicialmente el cuadro de texto estará vacio
        dialogText.text = String.Empty;

        //Por cada caracter en la linea de diálogo
        foreach (char ch in lineasDialogo[indiceLinea])
        {
            //Incrementamos el caracter al texto mostrado
            dialogText.text += ch;

            //Esperamos unas milesimas de segundo (real -> ignora la escala de tiempo seteada)
            yield return new WaitForSecondsRealtime(tiempoTipeo);
        }
    }
}
