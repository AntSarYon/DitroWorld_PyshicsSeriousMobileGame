using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCajaExp : MonoBehaviour
{
    [Header("Scene Rules Script")]
    [SerializeField] private LabExp1 sceneRules;

    [Header("ID del sensor")]
    [SerializeField] private int id;

    //--------------------------------------------------

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Iniciamos una variable de caja
        CajaDesplazamiento caja = null;

        //Si se trata del Sensor 2
        if (id == 2)
        {
            //Si el objeto tiene el componente de CajaDesplazamiento
            if (collision.transform.TryGetComponent<CajaDesplazamiento>(out caja))
            {
                //Invocamos al Script de Reglas para que cambie el Sprite del Objeto

            }
        }
    }


}
