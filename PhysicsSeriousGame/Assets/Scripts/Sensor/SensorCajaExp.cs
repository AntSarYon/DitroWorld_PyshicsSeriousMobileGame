using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCajaExp : MonoBehaviour
{
    [Header("Scene Rules Script")]
    [SerializeField] private LabExp2 sceneRules;

    [Header("Sprite de Caja Celeste")]
    [SerializeField] private Sprite blueBoxSprite;

    //--------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el objeto tiene el componente de CajaDesplazamiento
        if (collision.transform.CompareTag("SensoringObject"))
        {
            collision.transform.GetComponent<SensoringBox>().BoxReady = true;
            collision.transform.GetComponent<SpriteRenderer>().sprite = blueBoxSprite;
            sceneRules.boxesActivated++;
        }
    }


}
