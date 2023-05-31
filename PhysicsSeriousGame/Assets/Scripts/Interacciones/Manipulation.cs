using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
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

    //Tiempo que tomar� typear cada caracter
    private float tiempoTipeo = 0.025f;

    //Array que almacenar� las l�neas de di�logo del NPC
    [SerializeField, TextArea(4, 6)] private string[] lineasObservacion;

    //------------------------------------------------------------

    public void ManipulacionOprimida()
    {

    }
}
