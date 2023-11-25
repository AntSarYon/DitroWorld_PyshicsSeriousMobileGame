using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCajaInicio : MonoBehaviour
{

    [Header("Scene Rules Script")]
    [SerializeField] private LabExp2 sceneRules;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("SensoringObject"))
        {
            if (collision.transform.GetComponent<SensoringBox>().BoxReady)
            {
                sceneRules.boxesInPlace++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("SensoringObject"))
        {
            if (collision.transform.GetComponent<SensoringBox>().BoxReady)
            {
                sceneRules.boxesInPlace--;
            }
        }
    }
}
