using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //Creamos referencia de instancia
    public static GameManager Instance;

    //Lista de Personajes Jugables
    public List<Personajes> personajes;


    //Definimos e inicializamos una Lista de Resultados  
    public List<ResultadosEvento> listaResultados = new List<ResultadosEvento>();
    //ID Del Evento a los que los Datos pertenecen
    //Contadores para todas las acciones dispoinbles
    //Tiempo o Velocidad esta como valor de Enum
    //Accion esta como valor de Enum
    //Fuerza esta como valor de Enum
    //Solicitudes de ayuda esta como Int
    //Velocidad Obtenida esta como Float
    //DificultadPercibida esta como valor de Enum

    public float tiempoDeResolucionPromedio;                    // <-- LISTO
    public VelocidadDeResolucion velocidadDeResolucionActual;   // <-- LISTO

    public int contAccionEmpuje;
    public int contAccionImpulso;       // <-- LISTO
    public int contAccionGravedad;
    public int contAccionMasa;

    public int avgAccionEmpuje;
    public int avgAccionImpulso;
    public int avgAccionGravedad;       // <-- LISTO
    public int avgAccionMasa;

    public TipoDeAccion accionFavoritaActual;   // <-- LISTO
    public TipoDeFuerza fuerzaFavoritaActual;   // <-- LISTO

    public int avgSolicitudes;    // <-- LISTO
    public int numSolicitudesActuales;  // <-- LISTO

    //VariableS que indicaN el Nivel de Dificultad que Se aplicará al siguiente Evento que inicie
    public NivelDeDificultad siguienteDificultad;


    //-------------------------------------------------------------------------

    public void ActualizarParametrosActuales()
    {
        //Incrementamos el contador de accion para cada accion considerando el ultimo Evento añadido
        contAccionEmpuje += listaResultados[listaResultados.Count - 1].conteoDeAccionEmpuje;
        contAccionImpulso += listaResultados[listaResultados.Count - 1].conteoDeAccionImpulso;
        contAccionGravedad += listaResultados[listaResultados.Count - 1].conteoDeAccionGravedad;
        contAccionMasa += listaResultados[listaResultados.Count - 1].conteoDeAccionMasa;
        //Tambien incrementamos el contador de solicitudes
        numSolicitudesActuales += listaResultados[listaResultados.Count-1].solicitudesDeApoyo;

        //Obtenemos el promedio de Empujes por Evento
        avgAccionEmpuje = (int)Mathf.Round(contAccionEmpuje / listaResultados.Count);

        //Obtenemos el promedio de Impulsos por Evento
        avgAccionImpulso = (int)Mathf.Round(contAccionImpulso / listaResultados.Count);

        //Obtenemos el promedio de Cambios de Gravedad por Evento
        avgAccionGravedad = (int)Mathf.Round(contAccionGravedad / listaResultados.Count);

        //Obtenemos el promedio de Cambios en la Masa por Evento
        avgAccionMasa = (int)Mathf.Round(contAccionMasa / listaResultados.Count);

        //Obtenemos el promedio de Solicitudes a Crab por Evento
        avgSolicitudes = (int)Mathf.Round(numSolicitudesActuales / listaResultados.Count);

        //Obtenemos la Accion favorita del jugador hasta este momento
        accionFavoritaActual = AdaptationController.Instance.RegistrarAccionPreferida(avgAccionEmpuje, avgAccionImpulso, avgAccionGravedad, avgAccionMasa);

        //Obtenemos la Fuerza favorita del jugador hasta este momento
        fuerzaFavoritaActual = AdaptationController.Instance.ObtenerFuerzaPreferida(avgAccionEmpuje, avgAccionGravedad, avgAccionImpulso);

        //Reiniciamos el Tiempo de Resolucion Promedio a 0
        tiempoDeResolucionPromedio = 0.00f;

        // - - - - - - - - - - - - - - - - - - - - - - - - - - 

        //Por cada resultado de Evento en la Lista
        foreach (ResultadosEvento resultado in listaResultados)
        {
            //Incrementamos el tiempo obtenido por cada resultado
            tiempoDeResolucionPromedio += resultado.tiempoFinal;
        }

        //Dividimos el valor entre la cantidad de resultados en Lista
        tiempoDeResolucionPromedio /= listaResultados.Count;

        //Obtenemos la Velocidad de Reslucion Actual en base al tiempo
        velocidadDeResolucionActual = AdaptationController.Instance.CalcularVelocidadDeResolucion(tiempoDeResolucionPromedio);

        //Obtencion de valores para calculo de Dificultad Final
        int valAccion = AdaptationController.Instance.relacionTipoAccion[accionFavoritaActual];
        int valFuerza = AdaptationController.Instance.relacionTipoFuerza[fuerzaFavoritaActual];
        int valVelocidad = AdaptationController.Instance.relacionVelocidadDeResolucion[velocidadDeResolucionActual];

        //Asignamos el ValorDeApoyo en base a la cantidad de veces que se solicitó Ayuda a Crab
        int valApoyo = 0;
        if (avgSolicitudes <= 2) { valApoyo = 0; }
        else if (avgSolicitudes > 2 && avgSolicitudes <= 4) { valApoyo = 1; }
        else { valApoyo = 2; }

        //Realizmaos el Calculo considerando los Pesos que cada parametro tiene en
        float auxiliarCalculo = ((valAccion * 1.5f) + (valFuerza * 1.5f) + (valVelocidad * 4f) + (valApoyo * 3f))/10;

        //Asignacion de resultado redondeado
        int indiceNivelDeDificultad = (int)Mathf.Round(auxiliarCalculo);

        //Obtenemos la dificultad general percibida por el jugador hasta este momento del juego...
        NivelDeDificultad dificultadGeneralPercibida = AdaptationController.Instance.relacionNivel[indiceNivelDeDificultad];

        //----------------------------------------------------------------------------------------------------------
        //HASTA AQUI ESTAMOS OBTENIENDO LA DIFICULTAD QUE PERCIBE EL JUGADOR DEL JUEGO; PERO ES ESO LO QUE QUEREMOS?
        //----------------------------------------------------------------------------------------------------------

        //Si la dificultad percibida por el jugador (segun parametros), es ALTA
        if (dificultadGeneralPercibida == NivelDeDificultad.Alto)
        {
            //Hacemos que la SIGUIENTE DIFICULTAD sea menor (si se puede)

            if (listaResultados[listaResultados.Count - 1].dificultadDeDesafio == NivelDeDificultad.Alto)
            {
                siguienteDificultad = NivelDeDificultad.Medio;
            }
            else if (listaResultados[listaResultados.Count - 1].dificultadDeDesafio == NivelDeDificultad.Medio)
            {
                siguienteDificultad = NivelDeDificultad.Bajo;
            }
            else
            {
                //Si ya estamos en la Minima dificultad, la mantenemos
                siguienteDificultad = listaResultados[listaResultados.Count - 1].dificultadDeDesafio;
            }
        }

        //Si la dificultad percibida por el jugador (segun parametros), es BAJA
        else if (dificultadGeneralPercibida == NivelDeDificultad.Bajo)
        {
            //Hacemos que la SIGUIENTE DIFICULTAD sea Mayor (si se puede)

            if (listaResultados[listaResultados.Count - 1].dificultadDeDesafio == NivelDeDificultad.Bajo)
            {
                siguienteDificultad = NivelDeDificultad.Medio;
            }
            else if (listaResultados[listaResultados.Count - 1].dificultadDeDesafio == NivelDeDificultad.Medio)
            {
                siguienteDificultad = NivelDeDificultad.Alto;
            }
            else
            {
                //Si ya estamos en la Maxima dificultad, la mantenemos
                siguienteDificultad = listaResultados[listaResultados.Count - 1].dificultadDeDesafio;
            }
        }
        //En caso perciba una dificultad Media
        else
        {
            //Mantenemos la misma dificultad del ultimo Evento
            siguienteDificultad = listaResultados[listaResultados.Count - 1].dificultadDeDesafio;
        }

        print("La Proxima dificultad sera: " + AdaptationController.Instance.relacionNivelCalculo[siguienteDificultad]);

        
    }

    //---------------------------------------------------------------------------

    //EVENTO PARA CONTROLAR EL CUMPLIMIENTO DE UN OBJETIVO
    public event UnityAction OnEventAcomplished;

    //--------------------------------------------

    private void Awake()
    {
        ControlarUnicaInstancia();


    }

    private void Start()
    {

        //Inicializmaos variables para Adaptabilidad en 0
        tiempoDeResolucionPromedio = 0;                    // <-- LISTO
        velocidadDeResolucionActual = 0;     // <-- LISTO

        contAccionEmpuje = 0;
        contAccionImpulso = 0;         // <-- LISTO
        contAccionGravedad = 0;
        contAccionMasa = 0;

        avgAccionEmpuje = 0;
        avgAccionImpulso = 0;
        avgAccionGravedad = 0;         // <-- LISTO
        avgAccionMasa = 0;

        avgSolicitudes = 0;      // <-- LISTO
        numSolicitudesActuales = 0;    // <-- LISTO

        //El nivel de Dificultad empezara en MEDIO
        siguienteDificultad = NivelDeDificultad.Medio;
    }

    //----------------------------------------------------------
    //Invocador de Evento
    public void EventAcomplished()
    {
        OnEventAcomplished?.Invoke();
    }
    //---------------------------------------------------------------------------

    public void RecalcularParametros()
    {

    }


    //---------------------------------------------------------------------------

    private void ControlarUnicaInstancia()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //----------------------------------------------
}