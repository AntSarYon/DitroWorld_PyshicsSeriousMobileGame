using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitaController : MonoBehaviour
{
    //Angulo en que se visualiza al objeto
    private Vector2 anguloVision;

    [SerializeField] private Transform objetoSeguido;
    [SerializeField] private float distancia;
    [SerializeField] private Vector2 sensibilidadCamara;

    private float horizontalMouse;
    private float verticalMouse;

    private float incrementoZoom;

    // GETTERS Y SETTERS
    public Transform ObjetoSeguido { get => objetoSeguido; set => objetoSeguido = value; }

    //-----------------------------------------------

    private void Awake()
    {
        //Inicialimente el Objeto seguido por la camara siempre será el ObjetoCentral
        objetoSeguido = GameObject.Find("CentroExperimento").transform;

        //Inicializamos el angulo para que inicie siempre detrás del Punto inicial
        anguloVision = new Vector2(90 * Mathf.Deg2Rad, 0);
    }

    //---------------------------------------------------------------------------------

    private void Update()
    {
        //Si se ha movido el mouse en horizontal
        if (horizontalMouse != 0)
        {
            //Modificamos el angulo utilizando radiales; consideramos tmb la sensibilidad del Mouse
            anguloVision.x += horizontalMouse * Mathf.Deg2Rad * sensibilidadCamara.x * Time.deltaTime;
        }
        //Si se ha movido el mouse en vertical
        if (verticalMouse != 0)
        {
            //Modificamos el angulo utilizando radiales; consideramos tmb la sensibilidad del Mouse
            anguloVision.y += verticalMouse * Mathf.Deg2Rad * sensibilidadCamara.y * Time.deltaTime;

            //Limitmaos su valor para que no ascienda, o baje en exceso
            anguloVision.y = Mathf.Clamp(anguloVision.y, -80f * Mathf.Deg2Rad, 80f * Mathf.Deg2Rad);
        }
    }

    //---------------------------------------------------------------------------------

    private void LateUpdate()
    {
        //Actualizamos la orbita actualizando los angulos
        Vector3 orbita = new Vector3(
            Mathf.Cos(anguloVision.x) * Mathf.Cos(anguloVision.y),
            -Mathf.Sin(anguloVision.y),
            -Mathf.Sin(anguloVision.x) * Mathf.Cos(anguloVision.y)
            );

        //Actualizamos la distancia constantmente en base al incremento del Zoom;
        distancia = distancia + incrementoZoom * Time.deltaTime;

        //Actualizamos la posicion de la camara en base a la posiciond el Objeto seguido.
        transform.position = objetoSeguido.position + orbita * distancia;

        //Obtenemos la rotacion en una direccion especifica
        transform.rotation = Quaternion.LookRotation(objetoSeguido.position - transform.position);
    }

    //-------------------------------------------------------------------------------------------------

    // EVENTOS PARA LOS BOTONES CONTROLADORES DE CAMARA

    public void btnRightDown()
    {
        horizontalMouse = -25;
    }

    public void btnRightUp()
    {
        horizontalMouse = 0;
    }

    public void btnLeftDown()
    {
        horizontalMouse = 25;
    }
    public void btnLeftUp()
    {
        horizontalMouse = 0;
    }

    public void btnUpDown()
    {
        verticalMouse = -25;
    }
    public void btnUpUp()
    {
        verticalMouse = 0;
    }

    public void btnDownDown()
    {
        verticalMouse = 25;
    }
    public void btnDownUp()
    {
        verticalMouse = 0;
    }
    public void btnZoomInDown()
    {
        //Seteamos que, mientras se oprima, disminuiremos la distancia en 1
        incrementoZoom = -15;
    }
    public void btnZoomInUp()
    {
        //Incrementamos distancia en 1
        incrementoZoom = 0;
    }
    public void btnZoomOUTDown()
    {
        //Seteamos que, mientras se oprima, aumentaremos la distancia en 1
        incrementoZoom = 15;
    }
    public void btnZoomOUTUp()
    {
        //Incrementamos distancia en 1
        incrementoZoom = 0;
    }

}