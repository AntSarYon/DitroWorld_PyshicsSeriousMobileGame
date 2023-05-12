using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    //Referencia al Animator que controla la Transicion
    public Animator transitionAnimator;
    public int tiempoEspera;

    //------------------------------------------------------

    public void EmpezarJuego()
    {
        StartCoroutine(SceneLoad("EM_Principal"));
    }

    public IEnumerator SceneLoad(string siguienteEscena)
    {
        //Disparar Trigger para reproducir animacion de FadeIn
        transitionAnimator.SetTrigger("StartTransition");

        //Esperar un segundo
        yield return new WaitForSeconds(tiempoEspera);

        //Cargar la escena
        SceneManager.LoadScene(siguienteEscena);
    }
}
