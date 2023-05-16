using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    public GameObject player;
    private bool perseguir;
    [SerializeField] private float speed;
    [SerializeField] private float distanciaLimite;
    private CircleCollider2D mCollider;
    private Animator mAanimator;
    private SpriteRenderer mRenderer;

    //------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencias
        mCollider = GetComponent<CircleCollider2D>();
        mAanimator = GetComponent<Animator>();
        mRenderer = GetComponent<SpriteRenderer>();

        //Inicializamos Flags
        perseguir = false;

        //Iniciaizamos varibales
        //speed = 3f;
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        //transform.SetParent(player.transform);
    }

    //------------------------------------------------------

    private void Update()
    {
        //Si el flag de perseguir está habilitado
        if (perseguir)
        {
            MirarAlJugador();
            ControlarMovimiento();
        }

        else if (Vector2.Distance(transform.position, player.transform.position) > distanciaLimite)
        {
            perseguir = true;
            mAanimator.SetBool("IsWalking", true);
        }
    }

    private void MirarAlJugador()
    {
        if (player.transform.position.x > transform.position.x)
        {
            //Invertimos el Sprite
            mRenderer.flipX = true;
        }
        else
        {
            //Invertimos el Sprite
            mRenderer.flipX = false;
        }
    }

    private void ControlarMovimiento()
    {
        //Si la distancia entre el Dron y el jugador es mayor a 2.5.
        if (Vector2.Distance(transform.position, player.transform.position) > distanciaLimite)
        {
            //Nos movemos hacia la posicion del jugador
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        //Si la distancia entre el Dron y el jugador es de 2.5 unidades
        else if (Vector2.Distance(transform.position, player.transform.position) <= distanciaLimite)
        {
            //Desactivamos el Flag de seguimiento
            perseguir = false;
            mAanimator.SetBool("IsWalking", false);
        }
    }
}
