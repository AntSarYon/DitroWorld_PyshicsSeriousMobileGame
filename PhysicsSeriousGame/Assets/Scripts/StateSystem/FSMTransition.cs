using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // <-- Libreria necesaria para usar Atributos Funciones

// Este permitirá controlar la lógica de Cambio de Estado.
// Debe decirme 2 cosas:
// 1. ¿Podemos realizar transicion?
// 2. Si se da una transición; ¿Cuál seria el sigueinte estado?

public class FSMTransition<T> // <-- Definimos T porque debe ser utilizado por el Controller que hace uso del FSMState
{
    //Definimos Constructor
    public FSMTransition(Func<bool> isValid, Func<FSMState<T>> getNextState)
    {
        //Atributos Funcion que se deberan definir  (Estilo Landa)
        IsValid = isValid;
        GetNextState = getNextState;
    }

    //------------------------------------------------

    // First Class Funcion (Atributo Función) que devuelva un Booleano
    // Determina si es posible cambiar de Estado
    public Func<bool> IsValid { private set; get; }

    // First Class Funcion (Atributo Función) que devuelve el Componente utilizado
    //Determina cuál sera el Sigueinte Estado al cual deberemos pasar
    public Func<FSMState<T>> GetNextState { private set; get; }
}