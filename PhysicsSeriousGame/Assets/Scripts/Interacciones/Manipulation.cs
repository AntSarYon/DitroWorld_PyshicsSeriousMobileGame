using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
{
    #region VARIABLES

    //Referencia al icono de Manipulacion
    private GameObject iconoManipulacion;

    //Flag de Jugador cerca (para cuando choca)
    private bool jugadorCerca;

    private Rigidbody2D mRb;

    private Collision2D colisionConPlayer;

    #endregion
    //-----------------------------------------------------------
    //-----------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia a componente RB
        mRb = GetComponent<Rigidbody2D>();

        //Inicializamos flag de jugador cercano a falso
        jugadorCerca = false;

        //Obtenemos referencia al icono de Manipulacion del Objeto
        iconoManipulacion= transform.Find("icoManipulacion").gameObject;
    }

    //--------------------------------------------------------------------
    #region Controlar Click del Boton de manipulacion

    public void ManipulacionOprimida()
    {
        //Si el jugador esta cerca, el Flag de Dialogo proximo esta Activo
        if (jugadorCerca && Manager2D.Instance.FlagManipulacion)
        {
            //Movemos al objeto conviertiendo su RigidBody a Dinamico
            
            //Si existe un contacto entre el personaje y el Objeto manipulable
            if (colisionConPlayer != null)
            {
                //Hacemos su RigidBody Dinamico para que podmaos empujarlo
                mRb.bodyType = RigidbodyType2D.Dynamic;
            }
            //Si no existe contacto...
            else
            {
                //Lo devolvemos a su Estado Kinematico
                ConvertirAKinematico();
            }
        }
    }

    //-------------------------------------------------------------------------
    public void ConvertirAKinematico()
    {
        //Lo convertimos en kinematico
        mRb.bodyType= RigidbodyType2D.Kinematic;
        mRb.velocity = Vector3.zero;
    }

    #endregion
    //--------------------------------------------------------------------------------
    #region Activacion y Deteccion de Icono

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el jugador es quien entra en el Trigger del objeto maipulable
        if (collision.gameObject.CompareTag("Player"))
        {
            //Mostramos el icono de Manipulacion
            iconoManipulacion.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si el jugador es quien salde del Trigger del objeto maipulable
        if (collision.gameObject.CompareTag("Player"))
        {
            //Dsactivamos el icono de Manipulacion
            iconoManipulacion.SetActive(false);
        }
    }

    #endregion
    //--------------------------------------------------------------------------------
    #region Controlar Choque con el Objeto
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el jugador choca con el objeto maipulable
        if (collision.gameObject.CompareTag("Player"))
        {
            //Almacenamos la colisión
            colisionConPlayer = collision;

            //Activamos el Flag de jugadorCerca
            jugadorCerca = true;

            //Asignamos referencia a este Objeto como el propietario del Dialogo
            Manager2D.Instance.ObjetoManipulacion = this.gameObject;

            //Activamos el Flag de Evento de Dialogo proximo
            Manager2D.Instance.FlagManipulacion = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Si el jugador deja de chocar con el objeto manipulable
        if (collision.gameObject.CompareTag("Player"))
        {
            //Quitamos la referencia de colision
            colisionConPlayer = null;

            //Desactivamos el Flag de JugadorCerca
            jugadorCerca = false;

            //Cambiamos referencia a Objeto null
            Manager2D.Instance.ObjetoManipulacion = null;

            //Desactivamos el Flag de Evento de Manipulacion proximo
            Manager2D.Instance.FlagManipulacion = false;
        }
    }
   
    #endregion
}
