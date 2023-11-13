using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    //Referencia al Script con las reglas de la escena
    [SerializeField] private LabIntroRules SceneRules;

    //----------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el objeto que entra es un objeto sensorial (captado por sensores)
        if (collision.transform.CompareTag("SensoringObject"))
        {
            //Incrementemos el contador de sillas en el Script de Reglas
            SceneRules.ChairsCounter++;

            //Reproducimos el Sonido de Sensor Activo
            SceneRules.PlaySensorDetection();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si el objeto que sale es un objeto sensorial (captado por sensores)
        if (collision.transform.CompareTag("SensoringObject"))
        {
            //Reducimos el contador de sillas en el Script de Reglas
            SceneRules.ChairsCounter--;
        }
    }
}
