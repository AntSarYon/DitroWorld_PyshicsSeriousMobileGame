using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabExp3 : MonoBehaviour
{
    [Header("Evento 3D Tutorial")]
    [SerializeField] private GameObject evento3DTutorial;


    // Start is called before the first frame update
    void Start()
    {
        //Desactivamos el GO del Evento
        evento3DTutorial.SetActive(false);
    }

    //----------------------------------------------------------

    public void ActivateEvent()
    {
        //Activamos el GO del Evento
        evento3DTutorial.SetActive(true);
    }
}
