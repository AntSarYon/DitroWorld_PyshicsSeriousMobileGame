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
    
    [SerializeField]
    private float walkSpeed;

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
            transform.position + (mMoveInput * walkSpeed * Time.fixedDeltaTime)
        );
        
    }
    //-----------------------------------------------------
    private void OnMove(InputValue value)
    {
        //Almacenamos el Vector con la unidad de movimiento en X
        mMoveInput = value.Get<Vector2>().normalized;
    }

    //-----------------------------------------------------
    private void Animations()
    {
        if(mMoveInput.magnitude != 0)
        {
            mAnimator.SetFloat("Horizontal", mMoveInput.x);
            mAnimator.SetFloat("Vertical", mMoveInput.y);
            mAnimator.Play("Run");
        }
        else mAnimator.Play("Idle");
    }
}
