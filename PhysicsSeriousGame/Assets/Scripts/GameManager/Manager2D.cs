using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager2D : MonoBehaviour
{
    //Creamos referencia de instancia
    public static Manager2D Instance;

    [SerializeField] private Vector3 mMoveInput;

    //--------------------------------------------
    //GETTERS Y SETTERS
    public Vector3 MoveInput { get => mMoveInput; set => mMoveInput = value; }

    //--------------------------------------------

    private void Awake()
    {
        Instance = this;
    }

    //--------------------------------------------
}
