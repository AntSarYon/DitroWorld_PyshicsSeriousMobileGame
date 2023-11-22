using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabExp2 : MonoBehaviour
{
    [Header("Sprite de puerta Abierta")]
    [SerializeField] private Sprite doorOpenSprite;

    [Header("SpriteRenderer de la Puerta")]
    [SerializeField] private SpriteRenderer doorSR;

    [Header("Trigger de Salida")]
    [SerializeField] private GameObject exitTrigger;

    [Space]

    [Header("Sprite de Caja Celeste")]
    [SerializeField] private Sprite blueBoxSprite;

    [Header("SpriteRenderer de las Cajas")]
    [SerializeField] private SpriteRenderer box1spRender;
    [SerializeField] private SpriteRenderer box2spRender;

    [Space]

    [Header("Clip: Secreto desbloqueado")]
    [SerializeField] private AudioClip clipSecretUnlock;

    private AudioSource mAudioSource;

    private bool boxesAreReady;
    private bool doorIsOpen;

    //--------------------------------------------------

    void Awake()
    {
        //Obtenemos referencias a componentes
        mAudioSource = GetComponent<AudioSource>();

        //Iniciamos flags en Falso
        doorIsOpen = false;
    }

    //--------------------------------------------------

    void Start()
    {
        //Desactivamos el Trigger de la Salida
        exitTrigger.SetActive(false);
    }

    //--------------------------------------------------

    public void OpenDoor()
    {
        //Actualizamos el Sprite de puerta abierta
        doorSR.sprite = doorOpenSprite;

        //Reproducimos el sonido de Secreto desbloqueado
        mAudioSource.PlayOneShot(clipSecretUnlock, 1f);

        //Activamos el Trigger de Salida
        exitTrigger.SetActive(true);
    }

    //--------------------------------------------------

    public void UpdateBox()
    {

    }
}
