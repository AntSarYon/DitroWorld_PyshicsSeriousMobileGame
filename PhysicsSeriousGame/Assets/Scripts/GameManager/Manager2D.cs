using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager2D : MonoBehaviour
{
    //Creamos referencia de instancia
    public static Manager2D Instance;

    //Vector de Movimiento para personaje
    private Vector3 mMoveInput;

    //Flags para controlar si hay Eventos Activos
    private bool flagDialogo;
    private bool flagObservacion;
    private bool flagManipulacion;
    private bool flagComentarioRobot;
    private bool flagEvento3DProximo;

    private GameObject objetoDialogo;
    private GameObject objetoObservacion;
    private GameObject objetoManipulacion;
    private GameObject dron;


    //--------------------------------------------
    //GETTERS Y SETTERS
    public Vector3 MoveInput { get => mMoveInput; set => mMoveInput = value; }

    public bool FlagDialogo { get => flagDialogo; set => flagDialogo = value; }
    public bool FlagObservacion { get => flagObservacion; set => flagObservacion = value; }
    public bool FlagManipulacion { get => flagManipulacion; set => flagManipulacion = value; }
    public bool FlagComentarioRobot { get => flagComentarioRobot; set => flagComentarioRobot = value; }
    public bool FlagEvento3DProximo { get => flagEvento3DProximo; set => flagEvento3DProximo = value; }

    public GameObject ObjetoDialogo { get => objetoDialogo; set => objetoDialogo = value; }
    public GameObject ObjetoObservacion { get => objetoObservacion; set => objetoObservacion = value; }
    public GameObject ObjetoManipulacion { get => objetoManipulacion; set => objetoManipulacion = value; }
    public GameObject Dron { get => dron; set => dron = value; }


    //--------------------------------------------

    private void Awake()
    {
        //Declaramos que el Script en escena es la Instancia
        Instance = this;

        //Inicializamos Flags en Falso
        flagComentarioRobot = false;
        flagManipulacion = false;
        flagEvento3DProximo = false;
        flagDialogo = false;
        flagObservacion = false;
    }

    //--------------------------------------------

    private void Start()
    {
        //Obtenemos referencia al Dron
        dron = GameObject.Find("Dron");
    }
}
