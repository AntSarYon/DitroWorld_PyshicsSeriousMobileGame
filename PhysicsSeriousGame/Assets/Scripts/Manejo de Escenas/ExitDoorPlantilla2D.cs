using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExitDoorPlantilla2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Activamos el Flag y mostramos el icono de dialogo
            GameObject.Find("ScenesManager").GetComponent<ScenesManager>().CargarEscena("EM_Principal");
        }
    }
}
