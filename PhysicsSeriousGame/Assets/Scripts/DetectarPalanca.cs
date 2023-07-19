using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarPalanca : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Si el Auto entra en la Zona
        if (other.transform.CompareTag("ObjectivePhysicObject"))
        {
            GameObject.Find("Event3DConditions").GetComponent<EControllerPezca>().PalancaEnZona = true;
        }
    }

}
