using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3TutoEndingRules : MonoBehaviour
{
    [Header("Sprite de puerta Abierta")]
    [SerializeField] private Sprite doorOpenSprite;

    [Header("SpriteRenderer de la Puerta")]
    [SerializeField] private SpriteRenderer doorSR;

    [Header("Trigger de Salida")]
    [SerializeField] private GameObject exitTrigger;

    [Header("Clip: Secreto desbloqueado")]
    [SerializeField] private AudioClip clipSecretUnlock;

    private AudioSource mAudioSource;

    //--------------------------------------------------

    private void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

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
}
