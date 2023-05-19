using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //Creamos referencia de instancia
    public static GameManager Instance;

    //Lista de Personajes Jugables
    public List<Personajes> personajes;

    //--------------------------------------------

    private void Awake()
    {
        ControlarUnicaInstancia();
    }

    //--------------------------------------------
    private void ControlarUnicaInstancia()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}