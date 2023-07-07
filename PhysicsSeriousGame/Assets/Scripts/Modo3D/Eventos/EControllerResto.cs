using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace eventoOtro
{
    public class EControllerResto : EventsEDConditions
    {
        private float timer = 0;

        // TENEMOS UNA Lista heredada de los Objetos Fisicos dentro del nivel
        //protected List<GameObject> listaObjetosFisicos = new List<GameObject>();

        //-------------------------------------------------

        public override void ConfigurarObjetosFisicos()
        {

        }

        public override void EjecutarCondicionesDeInicio()
        {
            //Seteamos la Gravedad a 0
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }

        public override bool MonitorearVictoria()
        {
            timer += Time.deltaTime;
            if (timer >= 45)
            {
                return true;
            }
            else
            {
                return false;
            }

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