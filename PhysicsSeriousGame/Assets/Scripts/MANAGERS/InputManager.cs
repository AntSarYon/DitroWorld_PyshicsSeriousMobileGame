using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Direccion de Movimiento -> Inicializado en Zero
    private Vector2 moveDirection = Vector2.zero;

    //Accion de Zoom -> Inicializado en Zero
    private float ZoomValue = 0.0f;

    //Flags de Acciones oprimidas
    private bool interactPressed = false;
    private bool submitPressed = false;
    private bool crabPressed = false;
    private bool manipulatePressed = false;

    //Flags de Acciones para Movimiento de camara
    private bool camWPressed = false;
    private bool camAPressed = false;
    private bool camSPressed = false;
    private bool camDPressed = false;

    //Flag de Accion para Gravedad
    private bool gravityPressed = false;

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

    #region 3DInputs

    //--------------------------------------------------------------
    //EVENTO: Input de Interaccion Recibido

    public void ScrollPressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido, o Soltado...
        if (context.performed)
        {
            //Actualizamos la direccion de movimiento en base al Vector
            ZoomValue = context.ReadValue<float>();
        }

        else if (context.canceled)
        {
            ZoomValue = 0f;
        }
    }

    // - - - - - - - - - - - - - - - - - - - 
    public float GetScrollValue()
    {
        return ZoomValue;
    }

    public void CamWPressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido
        if (context.performed)
        {
            //Activamos el Flag
            camWPressed = true;
        }
        //Si el contexto del Input es que se ha Soltado
        else if (context.canceled)
        {
            //Desactivamos el Flag
            camWPressed = false;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public bool GetCamWPressed()
    {
        //Retornamos el valor del Flag de W oprimido;
        return camWPressed;
    }

    //-------------------------------------------------------------------------

    public void CamAPressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido
        if (context.performed)
        {
            //Activamos el Flag
            camAPressed = true;
        }
        //Si el contexto del Input es que se ha Soltado
        else if (context.canceled)
        {
            //Desactivamos el Flag
            camAPressed = false;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public bool GetCamAPressed()
    {
        //Retornamos el valor del Flag de A oprimido;
        return camAPressed;
    }

    //-------------------------------------------------------------------------

    public void CamSPressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido
        if (context.performed)
        {
            //Activamos el Flag
            camSPressed = true;
        }
        //Si el contexto del Input es que se ha Soltado
        else if (context.canceled)
        {
            //Desactivamos el Flag
            camSPressed = false;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public bool GetCamSPressed()
    {
        //Retornamos el valor del Flag de S oprimido;
        return camSPressed;
    }

    //-------------------------------------------------------------------------

    public void CamDPressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido
        if (context.performed)
        {
            //Activamos el Flag
            camDPressed = true;
        }
        //Si el contexto del Input es que se ha Soltado
        else if (context.canceled)
        {
            //Desactivamos el Flag
            camDPressed = false;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public bool GetCamDPressed()
    {
        //Retornamos el valor del Flag de D oprimido;
        return camDPressed;
    }

    //-------------------------------------------------------------------------

    public void GravityPressed(InputAction.CallbackContext context)
    {
        //Si el contexto del Input es que se ha Oprimido
        if (context.performed)
        {
            //Activamos el Flag
            gravityPressed = true;
        }
        //Si el contexto del Input es que se ha Soltado
        else if (context.canceled)
        {
            //Desactivamos el Flag
            gravityPressed = false;
        }
    }
    // - - - - - - - - - - - - - - - - - - - 
    public bool GetGravityPressed()
    {
        //Capturamos el valor del Flag de Interacción EN EL MOMENTO
        bool result = gravityPressed;
        //Lo convertimos a Falso
        gravityPressed = false;
        //Retornamos el valor que habiamos capturado antes de Falsearlo
        return result;
    }

    #endregion

    //-------------------------------------------------------------------------

    #region 2D INPUTS

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

    #endregion
}
