using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerInfoFisica : MonoBehaviour
{
    //Referencia al RigidBody
    private Rigidbody rb;

    //Normal de la superficie con la que estamos chocando
    private Vector3 normalDeSuperficie;
    private GameObject ObjetoSuperficie;

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
        //Si el objeto con el que chocamos esta en la Capa de FixedObject...
        if (collision.transform.gameObject.layer.Equals(16))
        {
            //Obtenemos la friccion de la superficie con la que estamos chocando, y la asignamos
            rb.drag = collision.transform.GetComponent<Rigidbody>().drag;

            ObjetoSuperficie = collision.gameObject;

            //Obtenemos la Normal de la superficie con la que entramos en contacto
            NormalDeSuperficie = collision.GetContact(0).normal;
        }
        else
        {
            //Si el objeto no era un FixedObject, la resistencia sera la misma que en el aire
            rb.drag = friccionEnElAire;
        }

    }

    //-------------------------------------------------

    private void OnCollisionExit(Collision collision)
    {
        //Si el objeto con el que dejamos de chocar estaba en la Capa de FixedObject...
        if (collision.transform.gameObject.layer.Equals(16))
        {
            //Asignamos la resistencia a la que estaba por default cuando esta en el aire
            rb.drag = friccionEnElAire;

            //Reseteamos la Normal
            NormalDeSuperficie = Vector3.zero;
        }
    }

}
