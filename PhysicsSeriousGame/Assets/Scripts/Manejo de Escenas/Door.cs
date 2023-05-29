using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //Nombre de la Escena a la cual saltaremos al chocar con puerta
    [SerializeField] private string siguienteEscena;

    //----------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si detectamos colisión del Jugador...
        if (collision.transform.CompareTag("Player"))
        {
            //Pasamos a la siguiente escena correspondiente
            ScenesManager.Instance.SolicitarCambioDeEscena(siguienteEscena);
        }
    }
}
