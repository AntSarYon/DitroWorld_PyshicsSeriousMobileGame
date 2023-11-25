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

    [Header("Clip: Secreto desbloqueado")]
    [SerializeField] private AudioClip clipSecretUnlock;

    [Header("Cajas en Posicion")]
    [HideInInspector] public int boxesActivated;
    [HideInInspector] public int boxesInPlace;

    [Header("Propiedades de las silla 1")]
    [SerializeField] private Manipulation manbox1;
    [SerializeField] private GameObject box1Trigger;
    [SerializeField] private GameObject box1VisualCue;

    [Header("Propiedades de las silla 2")]
    [SerializeField] private Manipulation manBox2;
    [SerializeField] private GameObject box2Trigger;
    [SerializeField] private GameObject box2VisualCue;

    private AudioSource mAudioSource;

    private bool boxesAreReady;
    private bool doorIsOpen;

    //--------------------------------------------------

    void Awake()
    {
        //Obtenemos referencias a componentes
        mAudioSource = GetComponent<AudioSource>();

        //Iniciamos flags en Falso
        manbox1.enabled = false;
        box1Trigger.SetActive(false);
        box1VisualCue.SetActive(false);

        manBox2.enabled = false;
        box2Trigger.SetActive(false);
        box2VisualCue.SetActive(false);

        boxesActivated = 0;
        boxesInPlace = 0;

        //Iniciamos con el Flag de cajas listas en Falso
        boxesAreReady = false;
        doorIsOpen = false;
    }

    //--------------------------------------------------

    void Update()
    {
        //Si ambas cajas estan en posición, y ambas cajas están activadas
        if (boxesInPlace == 2 && boxesActivated == 2)
        {
            //Activamos el Flag de Boxes Listas
            boxesAreReady = true;
        }
        //Si la Puerta est cerrada
        if (!doorIsOpen)
        {
            //Si las cajas estan listas
            if (boxesAreReady)
            {
                //Abrimos la puerta
                OpenDoor();
            }
        }
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

    public void EnableBoxes()
    {
        manbox1.enabled = true;
        box1Trigger.SetActive(true);
        box1VisualCue.SetActive(true);

        manBox2.enabled = true;
        box2Trigger.SetActive(true);
        box2VisualCue.SetActive(true);
    }
}
