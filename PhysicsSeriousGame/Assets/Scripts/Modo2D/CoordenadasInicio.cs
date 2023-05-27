using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoordenadasInicio : MonoBehaviour
{
    //Pariable que contieneal prerfab de jugador
    private GameObject personajeJugador;

    //Lista de coordenadas para aparicion
    [SerializeField] private List<InicioDeJugador> listaCoordenadas;

    private void Awake()
    {
        //Por cada coordenada de inicio en la Lista...
        foreach (InicioDeJugador coorIni in listaCoordenadas)
        {
            //Verificamos si el nombre de la ultima escena esta en la lista
            if (coorIni.NombreEscenaOrigen == ScenesManager.Instance.LastSceneName)
            {
                //Instanciamos al jugador en las coordenadas correspondientes
                InstaciarJugador(coorIni.transform.position);
                //Terminamos el Bucle
                break;
            }
        }
    }

    private void InstaciarJugador(Vector3 coor)
    {
        //Obtenemos el Indice de Personaje escogido a traves de las preferencias del jugador
        int indexPersonaje = PlayerPrefs.GetInt("PersonajeIndex");

        //Instanciamos el prefab del personaje en las coordenadas de Inicio.
        personajeJugador = GameObject.Instantiate(
            GameManager.Instance.personajes[indexPersonaje].personajeJugable,
            coor,
            Quaternion.identity
            );

        //Cambiamos el nombre del objeto instanciado a Player
        personajeJugador.name = "Player";

    }
}