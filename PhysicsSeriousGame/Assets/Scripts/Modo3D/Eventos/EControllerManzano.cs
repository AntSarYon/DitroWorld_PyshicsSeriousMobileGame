using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace eventoManzano
{
    public class EControllerManzano : EventsEDConditions
    {

        // TENEMOS UNA Lista heredada de los Objetos Fisicos dentro del nivel
        //protected List<GameObject> listaObjetosFisicos = new List<GameObject>();

        //-------------------------------------------------

        public override void ConfigurarObjetosFisicos()
        {
            
        }

        public override void EjecutarCondicionesDeInicio()
        {
            //Seteamos la Gravedad a 0
            Physics.gravity = Vector3.zero;
        }

        public override bool MonitorearVictoria()
        {
            int contManzanasListas = 0;
            bool victoria = false;

            foreach (GameObject go in listaObjetosFisicos)
            {
                if (go.GetComponent<Rigidbody>().drag == 5)
                {
                    contManzanasListas++;

                    if (contManzanasListas >= 4)
                    {
                        victoria = true;
                        break;
                    }
                }
            }

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

