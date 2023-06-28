using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum NivelDeDificultad
{
    Bajo, //0
    Medio, //1
    Alto, //2
};

public enum TipoDeAccion // PESO 0.3
{
    AccionGravedad, //0
    AccionImpulso, //1
    AccionEmpuje, //1
    AccionMasa //2
};

public enum TipoDeFuerza // PESO 0.2
{
    SinPreferencias, // 1
    Gravedad,   //0
    Impulso,   //1
    Empuje,    //2
};

public enum TiempoDeResolucion  // PESO 0.5
{
    Veloz, //0 | 0.00 - 60.00s
    Normal, //1 | 60.00 - 150.00s
    Lento //2 | 150.00 - (...)
}

//************************************************************************

public class ResultadosEvento
{
    public TipoDeAccion accionFavorita;
    public TipoDeFuerza fuerzaFavorita;
    public TiempoDeResolucion tiempoFinal;
    public float velocidadObtenida;

    public NivelDeDificultad dificultadPercibida;

    //-------------------------------------------------------------------------------
    //Función para calcular la dificultad que tuvo el usuario para superar el desafío
    public NivelDeDificultad CalcularDificultadDeEventoPercibida()
    {
        int indiceNivelDeDificultad = 0;

        int valAccion = AdaptationController.Instance.relacionTipoAccion[accionFavorita];
        int valFuerza = AdaptationController.Instance.relacionTipoFuerza[fuerzaFavorita];
        int valTiempo = AdaptationController.Instance.relacionTiempoDeResolucion[tiempoFinal];

        return AdaptationController.Instance.relacionNivel[indiceNivelDeDificultad];

    }

};

//***************************************************************************

public class AdaptationController : MonoBehaviour
{
    //Variable de Instancia publica
    public static AdaptationController Instance;

    //Diccionario con relacion de VALOR - NIVEL DE DIFICULTAD
    public Dictionary<int, NivelDeDificultad> relacionNivel = new Dictionary<int, NivelDeDificultad>()
    {
     {0, NivelDeDificultad.Bajo },
     {1, NivelDeDificultad.Medio},
     {2, NivelDeDificultad.Alto}
    };

    public Dictionary<TipoDeAccion, int> relacionTipoAccion = new Dictionary<TipoDeAccion, int>()
    {
        {TipoDeAccion.AccionGravedad, 2}, //Usado cuando el desafio se siente muy dificil
        {TipoDeAccion.AccionImpulso, 1},
        {TipoDeAccion.AccionEmpuje, 1},
        {TipoDeAccion.AccionMasa, 2},
    };

    public Dictionary<TipoDeFuerza, int> relacionTipoFuerza = new Dictionary<TipoDeFuerza, int>()
    {
        {TipoDeFuerza.SinPreferencias, 1},
        {TipoDeFuerza.Impulso, 0},
        {TipoDeFuerza.Empuje, 2},
        {TipoDeFuerza.Gravedad, 0}
    };

    public Dictionary<TiempoDeResolucion, int> relacionTiempoDeResolucion = new Dictionary<TiempoDeResolucion, int>()
    {
        {TiempoDeResolucion.Veloz, 0},
        {TiempoDeResolucion.Normal, 1},
        {TiempoDeResolucion.Lento, 2}
    };

    //VariableS que indicaN el Nivel de Dificultad ACTUAL
    private int indiceNivelActual;
    private NivelDeDificultad nivelActual;

    //Variables que indican el Promedio de indicadores sobre acciones y fuerza
    private float avgAccionFavoritaActual;
    private TipoDeAccion accionFavoritaActual;

    private float avgFuerzaFavoritaActual;
    private TipoDeFuerza fuerzaFavoritaActual;

    private float avgtiempoFinal;
    private TiempoDeResolucion tiempoFinal;

    

    //----------------------------------------------------------

    private void ControlarUnicaInstancia()
    {
        if (AdaptationController.Instance == null)
        {
            AdaptationController.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
