using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace eventoManzano
{
    public class EControllerManzano : EventsEDConditions
    {
        //Arreglo para tener referencias a todos los Postes en la Escena
        public GameObject[] arrPostes = new GameObject[4];

        //-------------------------------------------------------------------------

        public override void ConfigurarObjetosFisicos()
        {
            //Asignamos las propiedades fisicas de las Manzanas
            foreach (GameObject manzana in listaObjetosFisicos)
            {
                manzana.GetComponent<Rigidbody>().mass = 0.25f;
                manzana.GetComponent<Rigidbody>().drag = 0f;
                manzana.GetComponent<Rigidbody>().angularDrag = 0.75f;
            }
        }

        //-------------------------------------------------------------------------

        public override void EjecutarCondicionesDeInicio()
        {
            if (GameManager.Instance.siguienteDificultad == NivelDeDificultad.Alto)
            {
                //Seteamos la Gravedad a 0
                Physics.gravity = Vector3.zero;
            }
            else
            {
                //Seteamos la Gravedad a la Normal
                Physics.gravity = new Vector3(0, -9.81f, 0);
            }
            
        }

        //-------------------------------------------------------------------------

        public override bool MonitorearVictoria()
        {
            int postesGolpeados = 0;
            bool victoria = false;

            foreach (GameObject go in arrPostes)
            {
                //Si el poste esta desactivado
                if (go.activeSelf == false)
                {
                    postesGolpeados++;
                }
            }

            if (postesGolpeados == 4)
            {
                victoria = true;
            }
            else victoria = false;

            return victoria;
        }

        //-------------------------------------------------
       protected override void Start()
        {
            //Llamamos al Start heredado del padre
            base.Start();
        }
        //----------------------------------------------------
        protected override void Update()
        {
            //Llamamos al Update heredado del padre
            base.Update();
        }
    }
}

