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

    //Definimos e inicializamos una Lista de Resultados  
    public List<ResultadosEvento> listaResultados = new List<ResultadosEvento>();

    //EVENTO PARA CONTROLAR EL CUMPLIMIENTO DE UN OBJETIVO
    public event UnityAction OnEventAcomplished;

    //--------------------------------------------

    private void Awake()
    {
        ControlarUnicaInstancia();
    }

    //----------------------------------------------------------
    //Invocador de Evento
    public void EventAcomplished()
    {
        OnEventAcomplished?.Invoke();
    }
    //------------------------------------------------------------

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

    //----------------------------------------------
}