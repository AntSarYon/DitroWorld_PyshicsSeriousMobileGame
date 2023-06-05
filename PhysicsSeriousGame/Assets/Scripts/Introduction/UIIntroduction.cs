using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIntroduction : MonoBehaviour
{
    public void Despertar()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("2DLabPrincipal");
    }
}
