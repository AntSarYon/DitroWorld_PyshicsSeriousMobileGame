using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativaRotacion : MonoBehaviour
{
    private Vector3 posicionAnterior;
    
    [SerializeField] private Transform objetoSeguido;
    [SerializeField] private float distancia;
    //[SerializeField] private Vector2 sensibilidadCamara;

    private float incrementoZoom;

    //GETTERS Y SETTERS
    public Transform ObjetoSeguido { get => objetoSeguido; set => objetoSeguido = value; }

    //----------------------------------

    private void Awake()
    {
        //Inicialimente el Objeto seguido por la camara siempre será el ObjetoCentral
        objetoSeguido = GameObject.Find("CentroExperimento").transform;
        distancia = -20;
        incrementoZoom = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Cuando el usuario haga click
        if (Input.GetMouseButtonDown(0))
        {
            //Almacenamos el punto en la escena que coincide con la posicion del mouse
            posicionAnterior = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        //Si se esta manteniendo el click del raton
        if (Input.GetMouseButton(0))
        {
            //Actualizamos la direccion de rotacion en base a la diferencia entre la PosOrigen del MOuse y la actual
            Vector3 direccion = posicionAnterior - Camera.main.ScreenToViewportPoint(Input.mousePosition);

            //Hacemos que la posicion de la camara sea la misma que del objetivo (en un inicio)
            Camera.main.transform.position = objetoSeguido.position;// + direccion;

            //Rotamos la cámara alrededor del objeto en concreto
            Camera.main.transform.Rotate(new Vector3(1, 0, 0), direccion.y * 180);
            Camera.main.transform.Rotate(new Vector3(0, 1, 0), -direccion.x * 180, Space.World);

            distancia = distancia + incrementoZoom * Time.deltaTime;

            //Siempre estaremos a una distancia de 10 atras de él
            Camera.main.transform.Translate(new Vector3(0, 0, distancia));

            //Volvemos a capturas la posición Actual de la Camara para continuar con el calculo
            posicionAnterior = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    public void btnZoomInDown()
    {
        //Seteamos que, mientras se oprima, disminuiremos la distancia en 1
        incrementoZoom = +15;
    }
    public void btnZoomInUp()
    {
        //Incrementamos distancia en 1
        incrementoZoom = 0;
    }
    public void btnZoomOUTDown()
    {
        //Seteamos que, mientras se oprima, aumentaremos la distancia en 1
        incrementoZoom = -15;
    }
    public void btnZoomOUTUp()
    {
        //Incrementamos distancia en 1
        incrementoZoom = 0;
    }
}
