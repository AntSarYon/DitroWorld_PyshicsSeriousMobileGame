using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabExp1 : MonoBehaviour
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

    [Header("Clip: Sensor Activo")]
    [SerializeField] private AudioClip clipSensorActivated;

    [Header("Sillas en Posicion")]
    private bool allChairsInPlace;
    private int chairsCounter;

    [Header("Propiedades de las silla 1")]
    [SerializeField] private Manipulation manChair1;
    [SerializeField] private GameObject chair1Trigger;
    [SerializeField] private GameObject chair1VisualCue;

    [Header("Propiedades de las silla 2")]
    [SerializeField] private Manipulation manChair2;
    [SerializeField] private GameObject chair2Trigger;
    [SerializeField] private GameObject chair2VisualCue;

    private AudioSource mAudioSource;

    public int ChairsCounter { get => chairsCounter; set => chairsCounter = value; }

    //--------------------------------------------------

    void Awake()
    {
        //Obtenemos referencia a componente
        mAudioSource = GetComponent<AudioSource>();

        //Inicializamos variables
        allChairsInPlace = false;
        chairsCounter = 0;

        //Desactivamos el Trigger
        exitTrigger.SetActive(false);
    }

    //--------------------------------------------------

    void Start()
    {
        //Desactivamos el Trigger de la Salida
        exitTrigger.SetActive(false);

        manChair1.enabled = false;
        chair1Trigger.SetActive(false);
        chair1VisualCue.SetActive(false);

        manChair2.enabled = false;
        chair2Trigger.SetActive(false);
        chair2VisualCue.SetActive(false);
    }

    //--------------------------------------------------

    void Update()
    {
        //Si el flag de las 2 sillas en posicion AUN ESTA DESACTIVADO...
        if (!allChairsInPlace)
        {
            //Detectamos si el contador de sillas llega a 3
            if (chairsCounter == 2)
            {
                //En ese caso, abrimos las puertas
                OpenDoor();

                //Activamos el Flag de 3 sillas en posicion
                allChairsInPlace = true;
            }
        }
    }

    //--------------------------------------------------

    public void EnableChairs()
    {
        manChair1.enabled = true;
        chair1Trigger.SetActive(true);
        chair1VisualCue.SetActive(true);

        manChair2.enabled = true;
        chair2Trigger.SetActive(true);
        chair2VisualCue.SetActive(true);
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

    public void PlaySensorDetection()
    {
        mAudioSource.PlayOneShot(clipSensorActivated, 1f);
    }
}
