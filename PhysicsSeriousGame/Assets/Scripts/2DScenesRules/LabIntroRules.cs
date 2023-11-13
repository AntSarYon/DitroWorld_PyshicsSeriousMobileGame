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
    [SerializeField] private SpriteRenderer[] doorSprites = new SpriteRenderer[2];

    [Header("Triggers de Salida")]
    [SerializeField] private GameObject[] exitTriggers = new GameObject[2];

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

        //Por cada Trigger de salida
        foreach (GameObject trigger in exitTriggers)
        {
            //Desactivamos el GameObject
            trigger.SetActive(false);
        }
    }

    //-------------------------------------------------------------------------

    private void Update()
    {
        print(ChairsCounter);

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

        //Por cada Sprite renderer en la lista
        foreach (SpriteRenderer sr in doorSprites)
        {
            //Asignamos el Sprite de Puerta abierta
            sr.sprite = openDoorSprite;
        }

        //Cambiamos el Sprite del computador a Naranja
        computerSprite.sprite = orangeComputer;

        //Por cada Trigger de salida
        foreach (GameObject trigger in exitTriggers)
        {
            //Activamos el GameObject
            trigger.SetActive(true);
        }
    }

    //-------------------------------------------------------------------------

    private void CloseDoors()
    {
        mAudioSource.PlayOneShot(clipDoorLocked, 0.30f);
        //Por cada Sprite renderer en la lista
        foreach (SpriteRenderer sr in doorSprites)
        {
            //Asignamos el Sprite de Puerta abierta
            sr.sprite = closeDoorSprite;
        }

        //Cambiamos el Sprite del computador a Celeste
        computerSprite.sprite = blueComputer;

        //Por cada Trigger de salida
        foreach (GameObject trigger in exitTriggers)
        {
            //Desactivamos el GameObject
            trigger.SetActive(false);
        }
    }

    //-------------------------------------------------------------------------

    public void PlaySensorDetection()
    {
        mAudioSource.PlayOneShot(clipSensorActivated, 1f);
    }

}
