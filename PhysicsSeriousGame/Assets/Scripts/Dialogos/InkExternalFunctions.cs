using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story) //Puede agregarse otro parametro de ser necesario...
    {
        /*
        story.BindExternalFunction("funcionEjemplo", (string parametroEjemploInk) =>
            FuncionEjemplo(parametroEjemploInk)
            );

        //Se debera agregar uno nuevo por cada Funcion Externa creada
        
         story.BindExternalFunction("funcionEjemplo", (string parametroEjemploInk) => 
            FuncionEjemplo(parametroEjemploInk)
            );
         */

        /*
         story.BindExternalFunction("funcionEjemplo", (string parametroEjemploInk) => 
            FuncionEjemplo(parametroEjemploInk)
            );
         */

    }

    //--------------------------------------------------------------------------------------

    public void Unbind(Story story)
    {   /*
        story.UnbindExternalFunction("funcionEjemplo");
        */
    }

    #region External Functions INK

    public void FuncionEjemplo(string ejemplo)
    {   /*
        Debug.Log("Las funciones externas funcionan: " + ejemplo);
        */
    }

    #endregion
}
