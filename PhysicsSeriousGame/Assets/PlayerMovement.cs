using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D mRb;
    private Collider2D mCollider;
    private Vector2 mMoveInput;
    private float walkSpeed;

    void Awake()
    {
        mRb = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<Collider2D>();

        walkSpeed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        /*mRb.velocity = new Vector2(
            mMoveInput.x, 
            mMoveInput.y
            ).normalized * walkSpeed;*/
    }

    private void OnMove(InputValue value)
    {
        //Almacenamos el Vector con la unidad de movimiento en X
        mMoveInput = value.Get<Vector2>();
        mRb.velocity = new Vector2(
            mMoveInput.x,
            mMoveInput.y
            ).normalized * walkSpeed;

    }
}
