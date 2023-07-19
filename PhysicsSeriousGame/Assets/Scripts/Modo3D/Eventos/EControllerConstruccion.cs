using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EControllerConstruccion : EventsEDConditions
{
    private TouchDeteccion playerTouch;

    public override void ConfigurarObjetosFisicos()
    {
        //throw new System.NotImplementedException();
    }

    public override void EjecutarCondicionesDeInicio()
    {
        playerTouch = GameObject.Find("CameraPlayer").GetComponent<TouchDeteccion>();

        //Seteamos la Gravedad hacia abajo
        Physics.gravity = new Vector3(0, -9.81f, 0);

        if (GameManager.Instance.siguienteDificultad == NivelDeDificultad.Alto || GameManager.Instance.siguienteDificultad == NivelDeDificultad.Medio)
        {
            //Desactivamos el Boton de Gravedad
            ButtonsManager.Instance.BtnGravedad.SetActive(false);
        }
    }

    public override bool MonitorearVictoria()
    {
        if (playerTouch.RigidBodySeleccionado != null)
        {
            if (playerTouch.RigidBodySeleccionado.transform.CompareTag("ObjectiveFixedObject"))
            {
                return true;
            }
            else return false;
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
