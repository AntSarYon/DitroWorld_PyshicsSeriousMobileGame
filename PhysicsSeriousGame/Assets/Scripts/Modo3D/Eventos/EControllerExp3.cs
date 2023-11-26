using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace eventoExp3
{
    public class EControllerExp3 : EventsEDConditions
    {
        //Arreglo para tener referencias a todos los Senores en la Escena
        public GameObject[] arrPostes = new GameObject[3];

        //-------------------------------------------------------------------------

        public override void ConfigurarObjetosFisicos()
        {
            //Asignamos las propiedades fisicas de las Pelotas
            foreach (GameObject pelota in listaObjetosFisicos)
            {
                pelota.GetComponent<Rigidbody>().mass = 1f;
                pelota.GetComponent<Rigidbody>().drag = 0f;
                pelota.GetComponent<Rigidbody>().angularDrag = 0.75f;
            }
        }

        public override void EjecutarCondicionesDeInicio()
        {
            //Seteamos la Gravedad a la Normal
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }

        public override bool MonitorearVictoria()
        {
            int sensoresGolpeados = 0;
            bool victoria = false;

            foreach (GameObject go in arrPostes)
            {
                //Si el poste esta desactivado
                if (go.activeSelf == false)
                {
                    sensoresGolpeados++;
                }
            }

            if (sensoresGolpeados == 3)
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
