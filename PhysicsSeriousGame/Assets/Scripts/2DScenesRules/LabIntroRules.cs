using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LabIntroRules : MonoBehaviour
{
    [Header("Sillas en Posicion")]
    private bool allChairsInPlace;
    private int chairsCounter;

    [Header("Sprite de Computadora Naranja")]
    [SerializeField] private Sprite orangeComputer;

    [Header("Sprite de Computadora Celeste")]
    [SerializeField] private Sprite blueComputer;

    [Header("Sprite de Puerta abierta")]
    [SerializeField] private Sprite openDoorSprite;
    [Header("Sprite de Puerta cerrada")]
    [SerializeField] private Sprite closeDoorSprite;

    [Header("Computador que cambiara de color")]
    [SerializeField] private SpriteRenderer computerSprite;

    [Header("Puertas que se abriran")]
    [SerializeField] private SpriteRenderer doorSprite;

    [Header("Triggers de Salida")]
    [SerializeField] private GameObject exitTrigger;

    [Header("Clip: Secreto desbloqueado")]
    [SerializeField] private AudioClip clipSecretUnlock;

    [Header("Clip: Secreto desbloqueado")]
    [SerializeField] private AudioClip clipDoorLocked;

    [Header("Clip: Sensor Activo")]
    [SerializeField] private AudioClip clipSensorActivated;

    private AudioSource mAudioSource;

    public int ChairsCounter { get => chairsCounter; set => chairsCounter = value; }

    //-----------------------------------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia a componente
        mAudioSource = GetComponent<AudioSource>();

        //Inicializamos variables
        allChairsInPlace = false;
        chairsCounter = 0;

        //Desactivamos el Trigger
        exitTrigger.SetActive(false);
        
    }

    //-------------------------------------------------------------------------

    private void Update()
    {
        //Si el flag de las 3 sillas en posicion AUN ESTA DESACTIVADO...
        if (!allChairsInPlace)
        {
            //Detectamos si el contador de sillas llega a 3
            if (chairsCounter == 3)
            {
                //En ese caso, abrimos las puertas
                OpenDoors();

                //Activamos el Flag de 3 sillas en posicion
                allChairsInPlace=true;
            }
        }

        //En caso de que el Flag ya esté activado
        else
        {
            //Si el contador de sillas en posicion disminuye
            if (chairsCounter < 3)
            {
                //Cerramos las puertas
                CloseDoors();

                //Activamos el Flag de 3 sillas en posicion
                allChairsInPlace = false;
            }
        }
        
    }

    //-------------------------------------------------------------------------

    private void OpenDoors()
    {
        mAudioSource.PlayOneShot(clipSecretUnlock, 1f);

        //Asignamos el Sprite de Puerta abierta
        doorSprite.sprite = openDoorSprite;

        //Cambiamos el Sprite del computador a Naranja
        computerSprite.sprite = orangeComputer;

        //Activamos el GameObject
        exitTrigger.SetActive(true);
        
    }

    //-------------------------------------------------------------------------

    private void CloseDoors()
    {
        mAudioSource.PlayOneShot(clipDoorLocked, 0.30f);
        
        //Asignamos el Sprite de Puerta abierta
        doorSprite.sprite = closeDoorSprite;

        //Cambiamos el Sprite del computador a Celeste
        computerSprite.sprite = blueComputer;

        //Desactivamos el GameObject
        exitTrigger.SetActive(false);
    }

    //-------------------------------------------------------------------------

    public void PlaySensorDetection()
    {
        mAudioSource.PlayOneShot(clipSensorActivated, 1f);
    }

}
