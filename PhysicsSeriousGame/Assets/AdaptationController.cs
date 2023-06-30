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

public enum TipoDeAccion // PESO 0.15
{
    AccionGravedad, //0
    AccionImpulso, //1
    AccionEmpuje, //1
    AccionMasa //2
};

public enum TipoDeFuerza // PESO 0.15
{
    SinPreferencias, // 1
    Gravedad,   //0
    Impulso,   //1
    Empuje,    //2
};

public enum VelocidadDeResolucion  // PESO 0.4
{
    Veloz, //0 | 0.00 - 60.00s
    Normal, //1 | 60.00 - 150.00s
    Lento //2 | 150.00 - (...)
}

//************************************************************************
//************************************************************************
public class ResultadosEvento
{
    //-----------------------------------
    //ATRIBUTOS
    public int IDEvento;

    public NivelDeDificultad dificultadDeDesafio;

    public int conteoDeAccionMasa;
    public int conteoDeAccionEmpuje;
    public int conteoDeAccionImpulso;
    public int conteoDeAccionGravedad;

    public TipoDeAccion accionFavorita;
    public TipoDeFuerza fuerzaFavorita;

    public float tiempoFinal;
    public VelocidadDeResolucion velocidadDeResolucion;

    public int solicitudesDeApoyo;

    public float velocidadObtenida;

    public NivelDeDificultad dificultadPercibida;

    //-------------------------------------------------------------------------------
    //Función para calcular la dificultad que tuvo el usuario para superar el desafío
    public NivelDeDificultad CalcularDificultadDeEventoPercibida()
    {

        //Obtencion de valores para calculo de Dificultad
        int valAccion = AdaptationController.Instance.relacionTipoAccion[accionFavorita];
        int valFuerza = AdaptationController.Instance.relacionTipoFuerza[fuerzaFavorita];
        int valVelocidad = AdaptationController.Instance.relacionVelocidadDeResolucion[velocidadDeResolucion];

        //Asignamos el ValorDeApoyo en base a la cantidad de veces que se solicitó Ayuda a Crab
        int valApoyo = 0;
        if (solicitudesDeApoyo <= 1){valApoyo = 0;}
        else if (solicitudesDeApoyo > 0 && solicitudesDeApoyo <= 3){valApoyo = 1;}
        else{valApoyo = 2;}

        //Realizmaos el Calculo considerando los Pesos que cada parametro tiene en
        float auxiliarCalculo = ((valAccion * 1.5f) + (valFuerza * 1.5f) + (valVelocidad * 4f) + (valApoyo * 3f))/10;

        //Asignacion de resultado redondeado
        int indiceNivelDeDificultad =  (int) Mathf.Round(auxiliarCalculo);

        //Retornamos el valor de Dificultad obtenido al utilizar la relación
        return AdaptationController.Instance.relacionNivel[indiceNivelDeDificultad];

    }

};
//***************************************************************************
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

    //Diccionario con relacion de VALOR - NIVEL DE DIFICULTAD
    public Dictionary<NivelDeDificultad, int> relacionNivelCalculo = new Dictionary<NivelDeDificultad, int>()
    {
     {NivelDeDificultad.Bajo, 0 },
     {NivelDeDificultad.Medio, 1},
     {NivelDeDificultad.Alto, 2}
    };

    public Dictionary<TipoDeAccion, int> relacionTipoAccion = new Dictionary<TipoDeAccion, int>()
    {
        {TipoDeAccion.AccionGravedad, 0}, //Usado cuando el desafio se siente muy sencillo
        {TipoDeAccion.AccionImpulso, 1},
        {TipoDeAccion.AccionEmpuje, 1},
        {TipoDeAccion.AccionMasa, 2}, //Usado cuando el desafio se siente muy dificil
    };

    public Dictionary<TipoDeFuerza, int> relacionTipoFuerza = new Dictionary<TipoDeFuerza, int>()
    {
        {TipoDeFuerza.SinPreferencias, 1},
        {TipoDeFuerza.Impulso, 1},
        {TipoDeFuerza.Empuje, 1}, 
        {TipoDeFuerza.Gravedad, 0}
    };

    public Dictionary<VelocidadDeResolucion, int> relacionVelocidadDeResolucion = new Dictionary<VelocidadDeResolucion, int>()
    {
        {VelocidadDeResolucion.Veloz, 0},
        {VelocidadDeResolucion.Normal, 1},
        {VelocidadDeResolucion.Lento, 2}
    };

    //----------------------------------------------------------------------------------------------------------

    public VelocidadDeResolucion CalcularVelocidadDeResolucion(float tiempoTranscurrido)
    {
        if (tiempoTranscurrido > 0.00f && tiempoTranscurrido < 60.00f)
        {
            return VelocidadDeResolucion.Veloz;
        }

        else if (tiempoTranscurrido > 60.00f && tiempoTranscurrido < 150.00f)
        {
            return VelocidadDeResolucion.Normal;
        }

        else
        {
            return VelocidadDeResolucion.Lento;
        }
    }

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    public TipoDeFuerza ObtenerFuerzaPreferida(int contEmpuje, int contGravedad, int contImpulso)
    {
        if (contEmpuje > contGravedad && contEmpuje > contImpulso)
        {
            return TipoDeFuerza.Empuje;
        }
        else if (contGravedad > contEmpuje && contGravedad > contImpulso)
        {
            return TipoDeFuerza.Gravedad;
        }
        else if (contImpulso > contGravedad && contImpulso > contEmpuje)
        {
            return TipoDeFuerza.Impulso;
        }
        else
        {
            return TipoDeFuerza.SinPreferencias;
        }
    }

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 


    public TipoDeAccion RegistrarAccionPreferida(int contEmpuje, int contImpulso, int contGravedad, int contModificacionDeMasa)
    {
        int indiceMax = 0;
        int valMaximo = 0;

        TipoDeAccion[] arrTiposAccion = new TipoDeAccion[4];
        arrTiposAccion[0] = TipoDeAccion.AccionEmpuje;
        arrTiposAccion[1] = TipoDeAccion.AccionImpulso;
        arrTiposAccion[2] = TipoDeAccion.AccionGravedad;
        arrTiposAccion[3] = TipoDeAccion.AccionMasa;

        int[] arrContadores = new int[4];
        arrContadores[0] = contEmpuje;
        arrContadores[1] = contImpulso;
        arrContadores[2] = contGravedad;
        arrContadores[3] = contModificacionDeMasa;

        for (int i = 0; i < arrContadores.Length; i++)
        {
            if (arrContadores[i] > valMaximo)
            {
                valMaximo = arrContadores[i];
                indiceMax = i;
            }
        }

        //Retornamos el Tipo de Accion mas utilizado
        return arrTiposAccion[indiceMax];
    }

    private void Awake()
    {
        ControlarUnicaInstancia();
    }

    //-------------------------------------------------------------------

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
