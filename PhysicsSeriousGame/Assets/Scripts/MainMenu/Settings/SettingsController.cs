using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public void VolverAlMenu()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("MainMenu");
    }
}
