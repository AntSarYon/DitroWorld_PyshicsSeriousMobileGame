using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Manager3D : MonoBehaviour
{
    //Creamos referencia de instancia
    public static Manager3D Instance;

    [SerializeField] private bool teVeo;
    //--------------------------------------------

    private void Awake()
    {
        Instance = this;
    }

    //--------------------------------------------
}
