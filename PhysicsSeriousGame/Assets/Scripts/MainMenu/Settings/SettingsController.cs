using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixerMusicaDeFondo;
    [SerializeField] private AudioMixer audioMixerEfectosDeSonido;

    public void VolverAlMenu()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("MainMenu");
    }

    public void AjustarMusicaDeFondo(float volumen)
    {
        audioMixerMusicaDeFondo.SetFloat("VolumenMusicaDeFondo", volumen);
    }

    public void AjustarEfectosDeSonido(float volumen)
    {
        audioMixerEfectosDeSonido.SetFloat("VolumenEfectosDeSonido", volumen);
    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);//
    }
}
