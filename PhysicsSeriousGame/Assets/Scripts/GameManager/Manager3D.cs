using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager3D : MonoBehaviour
{
    //Creamos referencia de instancia
    public static Manager3D Instance;

    //--------------------------------------------

    private void Awake()
    {
        ControlarUnicaInstancia();
    }

    //--------------------------------------------
    private void ControlarUnicaInstancia()
    {
        if (Manager3D.Instance == null)
        {
            Manager3D.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
