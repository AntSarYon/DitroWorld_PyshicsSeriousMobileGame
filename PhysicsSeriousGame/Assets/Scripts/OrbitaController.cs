using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitaController : MonoBehaviour
{
    //Angulo horizontal en que se visualiza al objeto
    private Vector2 anguloVision;

    [SerializeField] private Transform objetoSeguido;
    [SerializeField] private float distancia;
    [SerializeField] private Vector2 sensibilidadCamara;

    //-----------------------------------------------

    private void Awake()
    {
        //Inicializamos el angulo para que inicie siempre detrás del Punto inicial
        anguloVision = new Vector2(90 * Mathf.Deg2Rad, 0);
    }

    private void Start()
    {
        //Bloqueamos el Mouse para que no se visualice mientras jugamos
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Obtenemos los inputs en base a los ejes del Mouse
        float horizontalMouse = Input.GetAxisRaw("Mouse X");
        float verticalMouse = Input.GetAxisRaw("Mouse Y");

        //Si se ha movido el mouse en horizontal
        if (horizontalMouse != 0)
        {
            //Modificamos el angulo utilizando radiales; consideramos tmb la sensibilidad del Mouse
            anguloVision.x += horizontalMouse * Mathf.Deg2Rad * sensibilidadCamara.x;
        }
        //Si se ha movido el mouse en vertical
        if (verticalMouse != 0)
        {
            //Modificamos el angulo utilizando radiales; consideramos tmb la sensibilidad del Mouse
            anguloVision.y += verticalMouse * Mathf.Deg2Rad * sensibilidadCamara.y;

            //Limitmaos su valor para que no ascienda, o baje en exceso
            anguloVision.y = Mathf.Clamp(anguloVision.y, -80f * Mathf.Deg2Rad, 80f * Mathf.Deg2Rad);
        }
    }

    private void LateUpdate()
    {
        //Actualizamos la orbita actualizando los angulos
        Vector3 orbita = new Vector3(
            Mathf.Cos(anguloVision.x) * Mathf.Cos(anguloVision.y),
            -Mathf.Sin(anguloVision.y),
            -Mathf.Sin(anguloVision.x) * Mathf.Cos(anguloVision.y)
            );

        //Actualizamos la posicion de la camara en base a la posiciond el Objeto seguido.
        transform.position = objetoSeguido.position + orbita * distancia;
        
        //Obtenemos la rotacion en una direccion especifica
        transform.rotation = Quaternion.LookRotation(objetoSeguido.position - transform.position);
    }

}
    