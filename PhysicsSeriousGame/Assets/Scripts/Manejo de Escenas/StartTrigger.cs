using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    public void IniciarJuego()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("Lab-1");
    }
}
