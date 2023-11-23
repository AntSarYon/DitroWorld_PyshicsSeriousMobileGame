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

    [Header("Cajas en Posicion")]
    private bool allBoxesActivated;
    private int allBoxesInPlace;

    private int boxesInPlace;

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
        doorIsOpen = false;
    }

    //--------------------------------------------------

    void Start()
    {
        //Desactivamos el Trigger de la Salida
        exitTrigger.SetActive(false);

        manbox1.enabled = false;
        box1Trigger.SetActive(false);
        box1VisualCue.SetActive(false);

        manBox2.enabled = false;
        box2Trigger.SetActive(false);
        box2VisualCue.SetActive(false);
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
