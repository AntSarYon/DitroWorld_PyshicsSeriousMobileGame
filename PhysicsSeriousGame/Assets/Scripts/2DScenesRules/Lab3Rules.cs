using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3Rules : MonoBehaviour
{
    [Header("Evento 3D Tutorial")]
    [SerializeField] private GameObject evento3DTutorial;

    //----------------------------------------------------------

    void Start()
    {
        //Desactivamos el GO del Evento
        evento3DTutorial.SetActive(false);
    }

    //----------------------------------------------------------

    public void ActivateEvent()
    {
        //Activamos el GO del Evento
        evento3DTutorial?.SetActive(true);
    }
}
