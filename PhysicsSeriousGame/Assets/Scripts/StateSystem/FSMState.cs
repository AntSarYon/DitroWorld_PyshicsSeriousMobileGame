using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Es la Abstraccion de las Clases de los diferentes Estados de los NPCs
//NO PUEDE SER INSTANCIADA --> Es ABSTRACTA

public abstract class FSMState<T> // <-- Es Generica en cuanto que debe aceptar cualquier Script (Controller)
{
    //Deseo que esta clase tenga una referencia a un componente (T) de un
    //GameObject; pues de esa forma podre acceder a los dmemas componentes
    protected T mController;

    //Lista de Transiciones disponible para el Estado
    public List<FSMTransition<T>> Transitions;

    //----------------------------------------------------------
    //Definimos Constructor <-- Podr� ser utilizado por clases Hijas
    public FSMState(T controller)
    {
        mController = controller;
        Transitions = new List<FSMTransition<T>>();
    }

    //----------------------------------------------------------------------------
    // M�todos Abstractos <-- No rquieren implementaci�n, pues se sobreescribiran
    public abstract void OnEnter();
    public abstract void OnUpdate(float deltaTime);
    public abstract void OnExit();

    //Cualquier estado que herede de esta clase, tendr� que emplear estos 3 m�todos
}