using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D mRb;
    private CapsuleCollider2D mCollider;
    private Vector3 mMoveInput = Vector3.zero;
    private Animator mAnimator;
    [SerializeField]
    private float walkSpeed;

    void Awake()
    {
        mRb = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<CapsuleCollider2D>();
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Animations();
    }

    private void FixedUpdate()
    {
        /*mRb.velocity = new Vector2(
            mMoveInput.x, 
            mMoveInput.y
            ).normalized * walkSpeed;*/

        mRb.MovePosition(
            transform.position + (mMoveInput * walkSpeed * Time.fixedDeltaTime)
        );
        
    }

    private void OnMove(InputValue value)
    {
        //Almacenamos el Vector con la unidad de movimiento en X
        mMoveInput = value.Get<Vector2>().normalized;

        /*mRb.velocity = new Vector2(
            mMoveInput.x,
            mMoveInput.y
            ).normalized * walkSpeed;*/

    }

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
