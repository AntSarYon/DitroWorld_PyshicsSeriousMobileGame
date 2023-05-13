using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarAlClickear : MonoBehaviour
{
    [SerializeField] private List<AudioClip> listaAudios;

    //----------------------------------
    public void btnPlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot(listaAudios[0], 0.45f);
    }

    //----------------------------------

    public void btnOtherSound()
    {
        GetComponent<AudioSource>().PlayOneShot(listaAudios[1], 0.45f);
    }
}
