using Ink;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDetector : MonoBehaviour
{
    //Variable para contener la interaccion mas cercana
    private GameObject nearInteracion;

    public GameObject NearInteracion { get => nearInteracion; set => nearInteracion = value; }

    //--------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si la zona de colision corresponde a una Interaccion
        if (collision.transform.CompareTag("NPC Character") || 
            collision.transform.CompareTag("Evento3D") || 
            collision.transform.CompareTag("MANObject") || 
            collision.transform.CompareTag("Observation"))
        {
            nearInteracion = collision.gameObject;
        }
    }

    //--------------------------------------------------------------------

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si la zona de colision corresponde a una Interaccion
        if (collision.transform.CompareTag("NPC Character") ||
            collision.transform.CompareTag("Evento3D") ||
            collision.transform.CompareTag("MANObject") ||
            collision.transform.CompareTag("Observation"))
        {
            nearInteracion = null;
        }
    }
}
