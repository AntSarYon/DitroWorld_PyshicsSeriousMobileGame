using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace eventoManzano
{
    public class EControllerManzano : EventsEDConditions
    {

        //-------------------------------------------------

        public override void ConfigurarObjetosFisicos()
        {
            
        }

        public override void EjecutarCondicionesDeInicio()
        {
            Physics.gravity = Vector3.zero;
        }

        public override bool MonitorearVictoria()
        {
            return victoria;
        }

        // Start is called before the first frame update
        void Start()
        {
            EjecutarCondicionesDeInicio();

            print("¿Victoria? " + victoria);

            ObtenerObjetosFisicos();

            print(listaObjetosFisicos[0].name);
            print(listaObjetosFisicos[1].name);
            print("¡¡Funciona!!");
        }
    }
}

