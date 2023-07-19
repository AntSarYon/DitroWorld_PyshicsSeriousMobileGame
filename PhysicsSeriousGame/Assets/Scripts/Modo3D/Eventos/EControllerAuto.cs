using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EControllerAuto : EventsEDConditions
{
    private Rigidbody rbAuto;
    private bool autoEnZona = false;

    public bool AutoEnZona { get => autoEnZona; set => autoEnZona = value; }

    //---------------------------------------------------------------

    public override void EjecutarCondicionesDeInicio()
    {
        //Seteamos la Gravedad a 0
        Physics.gravity = new Vector3(0, -9.81f, 0);

        if (GameManager.Instance.siguienteDificultad == NivelDeDificultad.Alto)
        {
            //Desactivamos el Boton de Gravedad
            ButtonsManager.Instance.BtnGravedad.SetActive(false);
            rbAuto.mass = 125;
        }
    }

    public override bool MonitorearVictoria()
    {
        return autoEnZona;
    }

    public override void ConfigurarObjetosFisicos()
    {
       foreach (GameObject go in listaObjetosFisicos)
        {
            if (go.name == "Hatchback")
            {
                rbAuto = go.GetComponent<Rigidbody>();
                break;
            }
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
