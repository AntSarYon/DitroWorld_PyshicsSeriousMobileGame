using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3D : MonoBehaviour
{
    //Referencia al icono de Dialogo
    private GameObject iconoEvento;

    //Flags de Estado
    private bool jugadorCerca;

    [SerializeField] private string nombreEscena3D;

    [TextArea(3, 4)] public string ComentarioDron;

    public string NombreEscena3D { get => nombreEscena3D; set => nombreEscena3D = value; }

    //-------------------------------------------------------------
    private void Awake()
    {
        //Inicializamos flag de jugador cercano a falso
        jugadorCerca = false;

        //Obtenemos referencia al icono de excalamacion del NPC
        iconoEvento = transform.Find("icoEvento").gameObject;
    }

    //--------------------------------------------------------------

    public void BtnEvento3DOprimido()
    {
        //Si el jugador esta cerca, el Flag de Evento proximo esta Activo
        if (jugadorCerca && Manager2D.Instance.FlagEvento3DProximo)
        {
            ScenesManager.Instance.SolicitarCambioDeEscena(NombreEscena3D);
        }
    }

    //--------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el jugador entra a la zona de Dialogo
        if (collision.gameObject.CompareTag("Player"))
        {
            //Activamos el Flag de jugadorCerca
            jugadorCerca = true;
            //Mostramos el icono de dialogo
            iconoEvento.SetActive(true);
            //Asignamos referencia a este Objeto como el propietario del Evento3D
            Manager2D.Instance.ObjetoEvento3D = this.gameObject;
            //Activamos el Flag de Evento de Dialogo proximo
            Manager2D.Instance.FlagEvento3DProximo = true;
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
            iconoEvento.SetActive(false);
            //Asignamos a null la referencia a este Objeto 
            Manager2D.Instance.ObjetoEvento3D = null;
            //Desactivamos el Flag de Evento de Dialogo proximo
            Manager2D.Instance.FlagEvento3DProximo = false;
        }
    }
}
