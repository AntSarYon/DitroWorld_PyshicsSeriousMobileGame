using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorPlantilla2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("ScenesManager").GetComponent<ScenesManager>().SolicitarCambioDeEscena("Plantilla2D");
        }
    }
}
