using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private AudioClip pencilSound;

    private AudioSource mAudioSource;

    private void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    public void iniciarDialogo()
    {
        //Desactivamos el Flag de CrabHablando
        DialogueManager.Instance.speakerIsCrab = false;

        //Entramos al Modo de Dialogo -> Enviamos el InkJSON
        DialogueManager.Instance.EnterDialogueMode(inkJSON);
    }

    public void ReproducirLapiz()
    {
        mAudioSource.PlayOneShot(pencilSound,1);
    }

    public void IniciarJuego()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("2DLabPrincipal");
    }
}
