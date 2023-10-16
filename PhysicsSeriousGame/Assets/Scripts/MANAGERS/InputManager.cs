using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Direccion de Movimiento -> Inicializado en Zero
    private Vector2 moveDirection = Vector2.zero;

    //Flags de Acciones oprimidas
    private bool interactPressed = false;
    private bool submitPressed = false;
    private bool crabPressed = false;
    private bool manipulatePressed = false;

    //Variable de Instancia
    public static InputManager Instance;

    //--------------------------------------------------------------

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        Instance = this;
    }

    //--------------------------------------------------------------
    //EVENTO: Input de Movimiento Recibido
    public void MovePressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido, o Soltado...
        if (context.performed)
        {
            //Actualizamos la direccion de movimiento en base al Vector
            moveDirection = context.ReadValue<Vector2>().normalized;
            Debug.Log(moveDirection);
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>().normalized;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    //--------------------------------------------------------------
    //EVENTO: Input de Interaccion Recibido
    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido
        if (context.performed)
        {
            //Activamos el Flag
            interactPressed = true;
        }
        //Si el contexto del Input es que se ha Soltado
        else if (context.canceled)
        {
            //Desactivamos el Flag
            interactPressed = false;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public bool GetInteractPressed()
    {
        //Capturamos el valor del Flag de Interacción EN EL MOMENTO
        bool result = interactPressed;
        //Lo convertimos a Falso
        interactPressed = false;
        //Retornamos el valor que habiamos capturado antes de Falsearlo
        return result;
    }

    //-------------------------------------------------------------------------

    public void SubmitPressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido
        if (context.performed)
        {
            //Activamos el Flag
            submitPressed = true;
        }
        //Si el contexto del Input es que se ha Soltado
        else if (context.canceled)
        {
            //Desactivamos el Flag
            submitPressed = false;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public bool GetSubmitPressed()
    {
        //Capturamos el valor del Flag de Interacción EN EL MOMENTO
        bool result = submitPressed;
        //Lo convertimos a Falso
        submitPressed = false;
        //Retornamos el valor que habiamos capturado antes de Falsearlo
        return result;
    }
    // - - - - - - - - - - - - - - - - - - - 
    public void RegisterSubmitPressed()
    {
        //Pasamos el Flag de SUBMIT  a Falso
        submitPressed = false;
    }

    //--------------------------------------------------------------
    //EVENTO: Input de Interaccion Recibido
    public void CrabPressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido
        if (context.performed)
        {
            //Activamos el Flag
            crabPressed = true;
        }
        //Si el contexto del Input es que se ha Soltado
        else if (context.canceled)
        {
            //Desactivamos el Flag
            crabPressed = false;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public bool GetCrabPressed()
    {
        //Capturamos el valor del Flag de Interacción EN EL MOMENTO
        bool result = crabPressed;
        //Lo convertimos a Falso
        crabPressed = false;
        //Retornamos el valor que habiamos capturado antes de Falsearlo
        return result;
    }

    //--------------------------------------------------------------
    //EVENTO: Input de Interaccion Recibido
    public void ManipulatePressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido
        if (context.performed)
        {
            //Activamos el Flag
            manipulatePressed = true;
        }
        if (context.duration > 0.01f)
        {
            //Activamos el Flag
            manipulatePressed = true;
        }
        //Si el contexto del Input es que se ha Soltado
        else if (context.canceled)
        {
            //Desactivamos el Flag
            manipulatePressed = false;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public bool GetManipulatePressed()
    {
        //Capturamos el valor del Flag de Interacción EN EL MOMENTO
        bool result = manipulatePressed;

        return result;
    }
}
