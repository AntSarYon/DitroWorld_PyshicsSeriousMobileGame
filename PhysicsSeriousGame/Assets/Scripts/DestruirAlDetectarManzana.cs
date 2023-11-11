using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirAlDetectarManzana : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("PhysicObject"))
        {
            gameObject.SetActive(false);
        }
    }

}
