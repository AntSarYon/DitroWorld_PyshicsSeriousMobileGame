using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    //Referencia al jugador
    private GameObject player;
    private ObjectsDetector playerDetector;

    private GameObject targetToFollow;

    private bool follow;
    [SerializeField] private float speed;
    [SerializeField] private float distanciaLimite;

    private Animator mAanimator;
    private SpriteRenderer mRenderer;
    private CrabDialogueTrigger mDialogueTrigger;

    //-------------------------------------------------------------------------------

    private void Awake()
    {
        //Inicializamos componentes
        mAanimator = GetComponent<Animator>();
        mRenderer = GetComponent<SpriteRenderer>();
        mDialogueTrigger = GetComponent<CrabDialogueTrigger>();

        //Inicializamos Flags
        follow = false;

        //Iniciaizamos varibales
        speed = 3.75f;
        distanciaLimite = 1.75f;
    }

    //-------------------------------------------------------------------------------

    private void Start()
    {
        //Encontramos al Jugador y su Detector
        player = GameObject.Find("Player");
        playerDetector = player.GetComponent<ObjectsDetector>();

        //Lo asignamos como Objeto a seguir
        targetToFollow = player;

        //Asignamos que nuestra posicion sea la misma que la de él
        transform.position = targetToFollow.transform.position;
    }

    //-------------------------------------------------------------------------------

    private void Update()
    {
        //Controlamos cual será el Target a seguir
        ControlarTarget();

        //Si el flag de perseguir está habilitado
        if (follow)
        {
            MirarObjetivo();
            ControlarMovimiento();
        }
        //Caso contrario; si el Flag esta deshabilitado, pero la Disstancia entre el Dron y el TARGET supera el limite...
        else if (Vector2.Distance(transform.position, targetToFollow.transform.position) > distanciaLimite)
        {
            follow = true;
            mAanimator.SetBool("IsWalking", true);
        }
    }

    //-------------------------------------------------------------------------------

    private void ControlarTarget()
    {
        //Si hay un objeto cercano a la zona de interaccion del Jugador...
        if (playerDetector.NearInteracion != null)
        {
            //Lo asignamos como Target del Dron
            targetToFollow = playerDetector.NearInteracion;

            //Verificamos si tiene un InkJSON para el dron
            if (playerDetector.NearInteracion.TryGetComponent<CrabDialogue>(out CrabDialogue crabDialogueComp))
            {
                //Asignamos el Dialogo que esa Interaccion tenia prepara para CRAB
                mDialogueTrigger.InkJSON = crabDialogueComp.crabDialogueInkJSON;
            }
        }

        else //Caso contrario seguiremos al jugador 
        {
            targetToFollow = player;

            //Hacemos que el Ink de Dialogo sea el que esta por defecto
            mDialogueTrigger.InkJSON = mDialogueTrigger.DefaultInkJSON;
        }
            
    }

    //-------------------------------------------------------------------------------

    private void MirarObjetivo()
    {
        if (targetToFollow.transform.position.x > transform.position.x)
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

    //-------------------------------------------------------------------------------

    private void ControlarMovimiento()
    {
        //Si la distancia entre el Dron y el jugador es mayor a 2.5.
        if (Vector2.Distance(transform.position, targetToFollow.transform.position) > distanciaLimite)
        {
            //Nos movemos hacia la posicion del jugador
            transform.position = Vector2.MoveTowards(transform.position, targetToFollow.transform.position, speed * Time.deltaTime);
        }

        //Si la distancia entre el Dron y el jugador es de 2.5 unidades
        else if (Vector2.Distance(transform.position, targetToFollow.transform.position) <= distanciaLimite)
        {
            //Desactivamos el Flag de seguimiento
            follow = false;
            mAanimator.SetBool("IsWalking", false);
        }
    }
}
