using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronCommentsController : MonoBehaviour
{
    //Referencia al icono de Dialogo
    private GameObject iconoHablando;

    //Array que almacenará las líneas de diálogo (Por Defecto) del Dron
    [SerializeField, TextArea(3, 5)] private string[] lineasDialogo;

    private string dialogoEvento3D = "Segun mis cálculos, es posible llevar a cabo un EXPERIMENTO utilizando uno o más objetos en la cercanía.";
    private string dialogoManipulacion = "Parece que puedes mover este objeto usando algo de fuerza, trata de EMPUJARLO mientras mantienes oprimido el boton de MAMIPULACION";
    private string dialogoObservacion = "Mis sensores detectan un objeto interesante en las proximidades, ¿Logras VER algo?";
    private string dialogoDialogo = "Parece que alguien quiere DIALOGAR contigo, deberiamos acercarnos y hacer nuevos amigos.";

    //Variable para el Dialogo que se mostrará en pantalla
    private string dialogoSeleccionado;

    //Tiempo que tomará typear cada caracter
    private float tiempoTipeo = 0.025f;

    private bool dronEmpezoAHablar = false;

    // GETTER Y SETTER
    public string[] LineasDialogo { get => lineasDialogo; set => lineasDialogo = value; }
    public string DialogoEvento3D { get => dialogoEvento3D; set => dialogoEvento3D = value; }
    public string DialogoManipulacion { get => dialogoManipulacion; set => dialogoManipulacion = value; }
    public string DialogoObservacion { get => dialogoObservacion; set => dialogoObservacion = value; }
    public string DialogoDialogo { get => dialogoDialogo; set => dialogoDialogo = value; }
    public bool DronEmpezoAHablar { get => dronEmpezoAHablar; set => dronEmpezoAHablar = value; }

    //----------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia al icono de excalamacion del NPC
        iconoHablando = transform.Find("icoHablando").gameObject;
    }

    public void BtnComentarioDronOprimido()
    {
        //Si el dron aun no ha empezado a hablar
        if (!dronEmpezoAHablar)
        {
            //Activamos el icono de DronHablando
            iconoHablando.SetActive(true);

            //Mostramos solo el Boton del Dron
            UI2DController.Instance.MostrarSoloBotonEnCurso("BtnComentarioRobot");

            //Activamos Flag de Texto en Proceso para impedir que el Player se mueva
            Manager2D.Instance.TextoEnProceso = true;

            //Si hay un Objeto manipulable activo...
            if (Manager2D.Instance.FlagEvento3DProximo)
            {
                //Tomamos el dialogo DE Dron que tienen asignados...
                AsignarYActivarDialogo(Manager2D.Instance.ObjetoEvento3D.GetComponent<Event3D>().ComentarioDron);
            }
            //Si hay un Objeto manipulable activo...
            else if (Manager2D.Instance.FlagManipulacionVisible)
            {
                //Tomamos el dialogo DE Dron que tienen asignados...
                AsignarYActivarDialogo(Manager2D.Instance.ObjetoManipulacion.GetComponent<Manipulation>().ComentarioDron);
            }
            //Si hay un Objeto manipulable activo...
            else if (Manager2D.Instance.FlagObservacion)
            {
                //Tomamos el dialogo DE Dron que tienen asignados...
                AsignarYActivarDialogo(Manager2D.Instance.ObjetoObservacion.GetComponent<Observation>().ComentarioDron);
            }
            //Si hay un Objeto manipulable activo...
            else if (Manager2D.Instance.FlagDialogo)
            {
                //Tomamos el dialogo DE Dron que tienen asignados...
                AsignarYActivarDialogo(Manager2D.Instance.ObjetoDialogo.GetComponent<Dialog>().ComentarioDron);
            }
            else
            {
                //Sino, tomamos uno de los dialogos que tenemos por default
                AsignarYActivarDialogo(
                    lineasDialogo[
                        UnityEngine.Random.Range(
                            0, lineasDialogo.Length)
                        ]
                    );
            }

            //Activamos el Flag de Dron hablando
            dronEmpezoAHablar = true;
        }
        //Si el dron ya esta hablando...
        else
        {
            //En caso haya terminado de escribir la  linea
            if (UI2DController.Instance.InteractionText.text.Equals(dialogoSeleccionado))
            {
                //Cuando hagamos Click, terminamos el dialogo
                TerminarDialogo();
            }
            //En caso aun no se termine de escribir la linea completa
            else
            {
                //Cuando hagamos Click, Detenemos la corrutina de escritura en proceso
                StopAllCoroutines();

                //Mostramos la linea de dialogo completa
                UI2DController.Instance.InteractionText.text = dialogoSeleccionado;
            }
        }
    }
    //-----------------------------------------------------------------------
    private void AsignarYActivarDialogo(string dialogo)
    {
        //Asignamos la linea de dialogo correspondiente
        dialogoSeleccionado = dialogo;

        //Activamos el Panel de dialogo
        UI2DController.Instance.InteractionPanel.SetActive(true);

        //Seteamos la escala de tiempo a 0 para que todo se detenga
        //Time.timeScale = 0;

        //Iniciamos la corrutina para tippear la linea de dialogo
        StartCoroutine(MostrarLinea());
    }
    //--------------------------------------------------------------------------
    private void TerminarDialogo()
    {
        //Devolvemos la escala de tiempo a la normlaidad
        //Time.timeScale = 1;

        //Desactivamos el flag de Dialogo iniciado
        dronEmpezoAHablar = false;

        //Desactivamos el panel de dialogo
        UI2DController.Instance.InteractionPanel.SetActive(false);

        //Desactivamos el icono de DronHablando
        iconoHablando.SetActive(false);

        //Activamos todos los botones de interaccion de vuelta
        UI2DController.Instance.MostraTodosLosBotones();

        //Desactivamos Flag de Texto en Proceso para habilitar el movimiento del Player
        Manager2D.Instance.TextoEnProceso = false;

    }

    //--------------------------------------------------------------------------

    private IEnumerator MostrarLinea()
    {
        UI2DController.Instance.InteractionText.text = String.Empty;

        //Por cada caracter en la linea de diálogo seleccionada
        foreach (char ch in dialogoSeleccionado)
        {
            //Incrementamos el caracter al texto mostrado
            UI2DController.Instance.InteractionText.text += ch;

            //Esperamos unas milesimas de segundo (real -> ignora la escala de tiempo seteada)
            yield return new WaitForSecondsRealtime(tiempoTipeo);
        }
    }
}
