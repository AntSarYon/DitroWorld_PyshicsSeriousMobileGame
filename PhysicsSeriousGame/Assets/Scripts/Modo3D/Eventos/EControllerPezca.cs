using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EControllerPezca : EventsEDConditions
{
    private bool palancaEnZona = false;

    public bool PalancaEnZona { get => palancaEnZona; set => palancaEnZona = value; }

    public override void ConfigurarObjetosFisicos()
    {
        
    }

    public override void EjecutarCondicionesDeInicio()
    {
        
    }

    public override bool MonitorearVictoria()
    {
        return palancaEnZona;
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
