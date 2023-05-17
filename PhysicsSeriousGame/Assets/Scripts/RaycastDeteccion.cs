using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDeteccion : MonoBehaviour
{
    //Distancia del rayo
    [SerializeField] float rangoDeteccion = 25f;

    private void Awake()
    {
        //rangoDeteccion = 25f;
    }

    private void Update()
    {
        //Definimos varible que contendra la data del objeto impactado
        RaycastHit hit;

        //Si el Racast esta chocando algo -> Si lo hace, guardamos info en HIT
        if (Physics.Raycast(transform.position, transform.forward, out hit, rangoDeteccion))
        {
            //Mostramos el nombre del objeto
            Debug.Log(hit.transform.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        //Pintaremos el rayo de color azul
        Gizmos.color = Color.blue;

        //Dibujamos el rayo hacia el frente de la camar
        Gizmos.DrawRay(transform.position, transform.forward * rangoDeteccion);
    }
}
