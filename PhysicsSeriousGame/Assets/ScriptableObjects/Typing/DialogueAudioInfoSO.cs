using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueAudioInfo", menuName = "DialogueAudioInfoSO")]
public class DialogueAudioInfoSO : ScriptableObject
{
    public string id;

    public AudioClip dialogueTypingSoundClips;

    [Range(1, 4)] public int soundFrecuencyLevel = 2;

    [Range(-2, 2)] public float minPitch = 0.5f;
    [Range(-2, 2)] public float maxPitch = 2f;

    public bool stopAudioSource = true;
}
