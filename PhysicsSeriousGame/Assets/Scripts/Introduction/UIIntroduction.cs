using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIntroduction : MonoBehaviour
{
    [SerializeField] private Animator animatorCientifico;
    private Animator mAnimator;

    private AudioSource mAudioSource;
    [SerializeField] private AudioClip clipDespertando;
    [SerializeField] private AudioClip clipEmpezandoJuego;
    [SerializeField] private AudioClip clipLapiz;
    [SerializeField] private AudioClip clipCRAB;


    //-----------------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
        mAudioSource = GetComponent<AudioSource>();
    }

    //-----------------------------------------------------

    public void Despertar()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("2DLabPrincipal");
    }

    public void ReproducirDITRO()
    {
        mAudioSource.PlayOneShot(clipDespertando, 0.75f);
    }

    public void ReproducirLapiz()
    {
        mAudioSource.PlayOneShot(clipLapiz, 0.5f);
    }

    public void ReproducirCRAB()
    {
        mAudioSource.PlayOneShot(clipCRAB, 0.5f);
    }
    public void ReproducirEmpezandoJuego()
    {
        mAudioSource.PlayOneShot(clipEmpezandoJuego, 0.75f);
    }

    public void DetenerLapiz()
    {
        mAudioSource.Stop();
    }
}
