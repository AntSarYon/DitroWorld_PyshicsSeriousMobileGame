using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWinningZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Si el Auto entra en la Zona
        if (other.transform.CompareTag("ObjectiveFixedObject"))
        {
            GameObject.Find("Event3DConditions").GetComponent<EControllerAuto>().AutoEnZona = true;
        }
    }
}
