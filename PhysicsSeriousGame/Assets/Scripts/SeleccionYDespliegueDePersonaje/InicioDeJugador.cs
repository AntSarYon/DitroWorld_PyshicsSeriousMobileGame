using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioDeJugador : MonoBehaviour
{
    private GameObject personajeJugador;

    void Start()
    {
        //Obtenemos el Indice de Personaje escogido a traves de las preferencias del jugador
        int indexPersonaje = PlayerPrefs.GetInt("PersonajeIndex");

        //Instanciamos el prefab del personaje en las coordenadas de Inicio.
        personajeJugador = GameObject.Instantiate(
            GameManager.Instance.personajes[indexPersonaje].personajeJugable,
            transform.position,
            Quaternion.identity
            );

        //Cambiamos el nombre del objeto instanciad a Player
        personajeJugador.name = "Player";
    }
}
