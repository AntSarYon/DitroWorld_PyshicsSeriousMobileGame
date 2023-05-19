using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorSCM_Principal : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("ScenesManager").GetComponent<ScenesManager>().SolicitarCambioDeEscena("SCM_Principal");
        }
    }
}
