using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story) //Puede agregarse otro parametro de ser necesario...
    {
        
        story.BindExternalFunction("AnimarCientifico", (string nombreAnimacion) =>
            AnimarCientifico(nombreAnimacion)
            );

        //Se debera agregar uno nuevo por cada Funcion Externa creada
        
         story.BindExternalFunction("FadeInPrologo", () =>
            FadeInPrologo()
            );
         

    }

    //--------------------------------------------------------------------------------------

    public void Unbind(Story story)
    {   
        story.UnbindExternalFunction("AnimarCientifico");
        
    }

    #region External Functions INK

    public void AnimarCientifico(string nombreAnimacion)
    {
        //Obtenemos Animator del cientifico
        Animator scientistAnimator = GameObject.Find("Cientifico").GetComponent<Animator>();

        //Reproducimos la Animacion
        scientistAnimator.Play(nombreAnimacion);

    }
    

    public void FadeInPrologo()
    {
        //Obtenemos Animator de la UI del Prologo
        Animator ProUIAnimator = GameObject.Find("UI_Dialogue").GetComponent<Animator>();

        //Reproducimos la Animacion
        ProUIAnimator.Play("FadeIn");
    }

    #endregion
}
