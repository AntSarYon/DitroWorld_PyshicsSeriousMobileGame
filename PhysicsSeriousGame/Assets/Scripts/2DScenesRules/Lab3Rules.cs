using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3Rules : MonoBehaviour
{
    [Header("Evento 3D Tutorial")]
    [SerializeField] private GameObject evento3DTutorial;

    [Header("Dialogue Trigger del Cientifico")]
    [SerializeField] private DialogueTrigger scientistDialogue;

    [Header("Segundo Dialogo de Foreman")]
    [SerializeField] private TextAsset foremanSecondDialogue;

    //----------------------------------------------------------

    void Start()
    {
        //Si venimos de la Escena de Laboratorio Inicial Secundaria (No la Primera) o del Evento 3D
        if (ScenesManager.Instance.LastSceneName == "Lab-1_2" || ScenesManager.Instance.LastSceneName == "3DTutorial")
        {
            //Activamos  el GO del Evento
            evento3DTutorial.SetActive(true);

            //Le asignamos el segundo Dialogo al cientifico Foreman
            scientistDialogue.InkJSON = foremanSecondDialogue;
        }
        else
        {
            //Desactivamos el GO del Evento
            evento3DTutorial.SetActive(false);
        }
        
    }

    //----------------------------------------------------------

    public void ActivateEvent()
    {
        //Activamos el GO del Evento
        evento3DTutorial.SetActive(true);
    }
}
