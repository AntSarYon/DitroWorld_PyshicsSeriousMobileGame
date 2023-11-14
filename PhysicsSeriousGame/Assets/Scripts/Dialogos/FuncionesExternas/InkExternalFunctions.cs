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
        
         story.BindExternalFunction("AnimarCRAB", (string nombreAnimacion) =>
            AnimarCRAB(nombreAnimacion)
            );

        story.BindExternalFunction("FadeInPrologo", () =>
            FadeInPrologo()
            );

        story.BindExternalFunction("ActivateIntroEvent3D", () =>
            ActivateIntroEvent3D()
            );


    }

    //--------------------------------------------------------------------------------------

    public void Unbind(Story story)
    {   
        story.UnbindExternalFunction("AnimarCientifico");
        story.UnbindExternalFunction("AnimarCRAB");
        story.UnbindExternalFunction("FadeInPrologo");
        story.UnbindExternalFunction("ActivateIntroEvent3D");

    }

    #region External Functions INK

    public void AnimarCientifico(string nombreAnimacion)
    {
        //Obtenemos Animator del cientifico
        Animator scientistAnimator = GameObject.Find("Cientifico").GetComponent<Animator>();

        //Reproducimos la Animacion
        scientistAnimator.Play(nombreAnimacion);

    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    public void AnimarCRAB(string nombreAnimacion)
    {
        //Obtenemos Animator del cientifico
        Animator scientistAnimator = GameObject.Find("CRAB").GetComponent<Animator>();

        //Reproducimos la Animacion
        scientistAnimator.Play(nombreAnimacion);

    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    public void FadeInPrologo()
    {
        //Obtenemos Animator de la UI del Prologo
        Animator ProUIAnimator = GameObject.Find("UI_Dialogue").GetComponent<Animator>();

        //Reproducimos la Animacion
        ProUIAnimator.Play("FadeIn");
    }

    public void ActivateIntroEvent3D()
    {
        //Obtenemos Referencia al Script de Reglas
        Lab3Rules lr = GameObject.Find("SceneRules").GetComponent<Lab3Rules>();

        //Activamos el Evento 3D Tutorial
        lr.ActivateEvent();
    }

    #endregion
}
