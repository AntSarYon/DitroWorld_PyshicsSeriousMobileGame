using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSounds : MonoBehaviour
{
    private AudioSource mAudioSource;
    [SerializeField] private AudioClip screamingClip;
    [SerializeField] private AudioClip EmotionalClip;

    //------------------------------------------------------------

    private void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    //------------------------------------------------------------

    public void PlayScream()
    {
        mAudioSource.PlayOneShot(screamingClip, 0.45f);
    }

    //------------------------------------------------------------

    public void PlayEmotional()
    {
        mAudioSource.PlayOneShot(EmotionalClip, 0.45f);
    }
}
