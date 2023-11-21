using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [Header("Objetos de UI: FUERZA")]
    [SerializeField] private GameObject btnEmpujar;
    [SerializeField] private GameObject btnImpulsar;
    [SerializeField] private TextMeshProUGUI txtDescripcionFuerza;
    [SerializeField] private GameObject btnCambiarFuerza;

    [Header("Objetos de UI: GRAVEDAD")]
    [SerializeField] private GameObject btnGravedad;

    [Header("Objetos de UI: atributos")]
    [SerializeField] private GameObject uiMasa;
    [SerializeField] private GameObject uiVelocidad;
    [SerializeField] private GameObject uiFriccion;

    [Header("Objetos de UI: CONTROLAR CAMARA")]
    [SerializeField] private GameObject btnMovimiento;
    [SerializeField] private GameObject btnZoom;

    [SerializeField] private GameObject btnLiberar;
    [SerializeField] private GameObject btnCentrar;

    [Header("Objetos de UI: OBJETIVO")]
    //Referencia a Objetos de UI para el Objetivo
    [SerializeField] private GameObject btnObjective;

    [Header("Objetos de UI: CRAB")]
    [SerializeField] private GameObject optionCRAB;

    [Header("Objetos de UI: SALIDA")]
    [SerializeField] private GameObject btnSalida;

    //Referencia a componentes
    private AudioSource mAS;
    private Animator mAnimator;

    [HideInInspector] public int indexClip; 

    [Header("Clips de Tutoriales")]
    [SerializeField] private AudioClip[] clipsTutorial;

    //--------------------------------------------------------------

    private void Awake()
    {
        mAS = GetComponent<AudioSource>();
        mAnimator = GetComponent<Animator>();
    }

    //--------------------------------------------------------------

    public void PlayTutorial(int num)
    {
        indexClip = num;

        if (!mAS.isPlaying)
        {
            mAS.PlayOneShot(clipsTutorial[indexClip], 1f);
        }
        else
        {
            Invoke(nameof(PlayWirhDelay),3);
        }
        
    }

    //--------------------------------------------------------------

    public void PlayWirhDelay()
    {
        mAS.PlayOneShot(clipsTutorial[indexClip], 1f);
    }

    public void ExitTutorial()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("Lab-3_2");
    }
}
