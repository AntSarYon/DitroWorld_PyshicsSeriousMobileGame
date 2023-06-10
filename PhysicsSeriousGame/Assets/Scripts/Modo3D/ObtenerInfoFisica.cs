using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerInfoFisica : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 normalDeSuperficie;
    private float friccionEnElAire;
    public Vector3 NormalDeSuperficie { get => normalDeSuperficie; set => normalDeSuperficie = value; }

    //----------------------------------------------------

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        friccionEnElAire = rb.drag;
    }

    //-------------------------------------------------

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("FixedObject"))
        {
            //Obtenemos la friccion de la superficie con la que estamos chocando
            rb.drag = collision.transform.GetComponent<Rigidbody>().drag;
            NormalDeSuperficie = collision.GetContact(0).normal;
        }
        else
        {
            rb.drag = friccionEnElAire;
        }

    }

    //-------------------------------------------------

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("FixedObject"))
        {
            //Obtenemos la friccion de la superficie con la que estamos chocando
            rb.drag = friccionEnElAire;
            NormalDeSuperficie = Vector3.zero;
        }
    }

}
