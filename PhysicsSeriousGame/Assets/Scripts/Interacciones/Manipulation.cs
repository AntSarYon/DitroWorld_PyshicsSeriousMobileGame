using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
{
    #region VARIABLES

    //Flag de Jugador cerca (para cuando choca)
    private bool jugadorCerca;

    private Rigidbody2D mRb;

    private Collision2D colisionConPlayer;

    #endregion
    //-----------------------------------------------------------

    void Awake()
    {
        //Obtenemos referencia a componente RB
        mRb = GetComponent<Rigidbody2D>();

        //Inicializamos flag de jugador cercano a falso
        jugadorCerca = false;
    }

    //--------------------------------------------------------------------
    #region Controlar Click del Boton de manipulacion

    void Update()
    {
        //Si el jugador esta cerca, y esta oprimiendo el boton de Manipulación
        if (jugadorCerca && InputManager.Instance.GetManipulatePressed())
            ConvertirADinamico();
        else
            ConvertirAKinematico();
    }

    #endregion

    //-------------------------------------------------------------------------
    public void ConvertirADinamico()
    {
        //Hacemos su RigidBody Dinamico para que podmaos empujarlo
        mRb.bodyType = RigidbodyType2D.Dynamic;
    }

    //-------------------------------------------------------------------------
    public void ConvertirAKinematico()
    {
        //Lo convertimos en kinematico
        mRb.bodyType= RigidbodyType2D.Kinematic;
        mRb.velocity = Vector3.zero;
    }

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

            //Activamos el Flag de Manipulacion en proceso
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

            //Desactivamos el Flag de Manipulacion en proceso
            Manager2D.Instance.FlagManipulacion = false;
        }
    }

    #endregion
}
