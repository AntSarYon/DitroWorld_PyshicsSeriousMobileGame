using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables
{
    //Diccionario que contendra las variables
    private Dictionary<string, Ink.Runtime.Object> dicVariables;

    #region GETTER y SETTER del Diccionario
    public Dictionary<string, Ink.Runtime.Object> DicVariables { get => dicVariables; set => dicVariables = value; }
    #endregion

    //CONSTRUCTOR
    public DialogueVariables(TextAsset loadGlobalsJSON)
    {
        //Creamos la historia:
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);

        //Inicializamos el diccionario
        dicVariables = new Dictionary<string, Ink.Runtime.Object>();

        //Por cada variable Global definida en la Historia recien compilada
        foreach (string name in globalVariablesStory.variablesState)
        {
            //Obtenemos su valor actual
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);

            //Lo agregamos al Diccionario
            dicVariables.Add(name, value);

            Debug.Log("Variable " + name + " inicializada con: " + value);
        }
    }


    //---------------------------------------------------------------
    //---------------------------------------------------------------

    public void StartListening(Story story)
    {
        //Llevamos las variables (que existan) a la Historia (Ink)
        VariablesToStory(story);

        //Añadimos un Listener al Evento de Variable cambiada
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    //---------------------------------------------------------------

    public void StopListening(Story story)
    {
        //Eliminamos el Listener de Evento de Variable cambiada
        story.variablesState.variableChangedEvent -= VariableChanged;
        //Esto es principalmente para controlar que no haya más de un istener activo
    }

    //---------------------------------------------------------------
    // FUNCION LISTENER: Cambio de valor en variable
    // Inputs: NombreVariable; valor de Variable
    private void VariableChanged(string varName, Ink.Runtime.Object value)
    {
        //Controlamos si la variable forma parte del Diccionario global
        if (dicVariables.ContainsKey(varName))
        {
            //RESETEAMOS esa variable
            dicVariables.Remove(varName);
            dicVariables.Add(varName, value);
        }
    }

    //---------------------------------------------------------------
    //FUNCION: Llevar la variable (nuevo valor) a la Historias (Ink)
    private void VariablesToStory(Story story)
    {
        //Por cada elemento en el Diccionario de Var. Globales
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in dicVariables)
        {
            //Actualizamos la variable DENTRO DEL INK con su valor correspondiente
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }

    }
}
