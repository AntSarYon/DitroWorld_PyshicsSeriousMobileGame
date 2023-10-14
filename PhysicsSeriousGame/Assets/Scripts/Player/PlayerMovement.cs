using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Referencias a componentes
    private Rigidbody2D mRb;
    private CapsuleCollider2D mCollider;
    private Animator mAnimator;

    //Velocidad de movimiento
    private float walkSpeed = 4;

    //-----------------------------------------------------

    void Awake()
    {
        //Obtenemos referencias
        mRb = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<CapsuleCollider2D>();
        mAnimator = GetComponent<Animator>();
    }
    //-----------------------------------------------------

    private void Update()
    {
        //Controlamos las animaciones
        Animations();
    }
    //-----------------------------------------------------
    private void FixedUpdate()
    {
        //Mientras no se esté mostrando ningún Dialogo en pantalla
        if (!DialogueManager.Instance.dialogueIsPlaying)
        {
            //Movemos la posición del Player
            mRb.MovePosition(
                transform.position + 
                (new Vector3(
                    InputManager.Instance.GetMoveDirection().x,
                    InputManager.Instance.GetMoveDirection().y,
                    0) * walkSpeed * Time.fixedDeltaTime
                 )
            );
        }
    }

    //-----------------------------------------------------

    private void Animations()
    {
        //Mientras no se esté mostrando ningún Dialogo en pantalla
        if (!DialogueManager.Instance.dialogueIsPlaying)
        {
            //Si la dirección Input esta recibiendo algo...
            if (InputManager.Instance.GetMoveDirection().magnitude != 0)
            {
                //Modificamos los parametros de ambos ejes X e Y
                mAnimator.SetFloat("Horizontal", InputManager.Instance.GetMoveDirection().x);
                mAnimator.SetFloat("Vertical", InputManager.Instance.GetMoveDirection().y);

                //Reproducimos el BlendingTree de CORRER
                mAnimator.Play("Run");
            }
            //En caso no se esté recibiendo Input; se reproducirá el Blending Tree de IDLE
            else mAnimator.Play("Idle");

        }
        else
        {
            //En caso el Dialogo este activo, activamos el IDLE
            mAnimator.Play("Idle");
        }
    }
}
