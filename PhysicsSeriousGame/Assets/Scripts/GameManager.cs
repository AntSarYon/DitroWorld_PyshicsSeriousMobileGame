using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //Creamos referencia de instancia
    public static GameManager Instance;

    //--------------------------------------------

    private void Awake()
    {
        ControlarUnicaInstancia();
    }

    //--------------------------------------------
    private void ControlarUnicaInstancia()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}