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

    //Variable para la Dirección de movimiento
    private Vector3 mMoveInput = Vector3.zero;

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
        //Movemos la posición del Player
        mRb.MovePosition(
            transform.position + (Manager2D.Instance.MoveInput * walkSpeed * Time.fixedDeltaTime)
        );
        
    }
    //-----------------------------------------------------



    //-----------------------------------------------------
    private void Animations()
    {
        //Si la dirección Input esta recibiendo algo...
        if(Manager2D.Instance.MoveInput.magnitude != 0)
        {
            //Modificamos los parametros de ambos ejes X e Y
            mAnimator.SetFloat("Horizontal", Manager2D.Instance.MoveInput.x);
            mAnimator.SetFloat("Vertical", Manager2D.Instance.MoveInput.y);

            //Reproducimos el BlendingTree de CORRER
            mAnimator.Play("Run");
        }
        //En caso no se esté recibiendo Input; se reproducirá el Blending Tree de IDLE
        else mAnimator.Play("Idle");
    }
}
