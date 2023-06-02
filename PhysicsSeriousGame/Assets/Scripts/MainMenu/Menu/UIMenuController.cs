using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> listaAudios;
    private AudioSource mAudioSource;

    private void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    //---------------------------------------------------------------------

    public void btnPlaySound()
    {
        mAudioSource.PlayOneShot(listaAudios[0], 0.55f);
    }

    //---------------------------------------------------------------------

    public void btnOtherSound()
    {
        mAudioSource.PlayOneShot(listaAudios[1], 0.55f);
    }

    public void IrASeleccionDePersonaje()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("CharacterSelection");
    }

    public void IrASettings()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("Settings");
    }

    //---------------------------------------------------------------------------
    public void Salir()
    {
        //Cerramos el Juego
        Application.Quit();
    }
}
