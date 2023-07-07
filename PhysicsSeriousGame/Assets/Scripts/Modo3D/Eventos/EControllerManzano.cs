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

        public GameObject[] arrPostes = new GameObject[4];

        //-------------------------------------------------------------------------

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

