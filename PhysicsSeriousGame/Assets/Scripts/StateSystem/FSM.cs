using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Representa las FSM que se encuentren en uso 
public class FSM<T>
{
    //Utiliza 2 Estados
    public FSMState<T> InitialState; // <-- Estado Inicial de la Maquina de Estados
    public FSMState<T> CurrentState; // <-- Estado Actual de la Maquina de Estados

    //-------------------------------------------------
    // Constructor ------------------------------------
    public FSM(FSMState<T> initialState)
    {
        //Indicmaos solo el InitialState
        InitialState = initialState;
    }

    //-----------------------------------------------
    // Funcion que da inicio a la Maquina de Estados
    public void Begin()
    {
        //Declaramos que el Estado Actual sea precisamente el Estado Inicial
        CurrentState = InitialState;

        //Ejecuto el OnEnter del Estado Inicial
        CurrentState.OnEnter();
    }

    //-----------------------------------------
    // Funcion ejecutada por cada Frame (Similar a Update)
    public void Tick(float deltaTime)
    {
        //Revisamos las transiciones del Estado en que nos encontramos

        //Por cada Transicion en la Lista de Transiciones de este Estado
        foreach (var transition in CurrentState.Transitions)
        {
            //Si estamos en capacidad de llevar a cabo la transicion
            if (transition.IsValid())
            {
                //Ejecutamos la Salida del Estado Actual
                CurrentState.OnExit();
                // Hacemos que el Estado Actual sea el siguiente según la Transición
                CurrentState = transition.GetNextState();
                //Iniciamos el nuevo Estado
                CurrentState.OnEnter();
                //Rompemos el Bucle
                break;
            }
        }

        //Actualizamos el Estado en cada frame
        CurrentState.OnUpdate(deltaTime);
    }
}