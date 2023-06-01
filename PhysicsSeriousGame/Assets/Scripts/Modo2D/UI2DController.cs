using System;
using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI2DController : MonoBehaviour
{
    //Variable de Instancia
    public static UI2DController Instance;

    //Referencia a Componentes de Audio
    private AudioSource mAudioSource;
    [SerializeField] AudioClip clipClicks;
    [SerializeField] AudioClip clipManipulacion;
    [SerializeField] AudioClip clipEvento3D;
    [SerializeField] AudioClip[] clipsDron = new AudioClip[5];
    
    //Referencia al Objeto de UI de Transicion
    private Transform objTransicion;

    //Referencia a Objetos de UI para la ineraccion
    [SerializeField] private GameObject interactionPanel;
    [SerializeField] private TextMeshProUGUI interactionText;
    

    public GameObject InteractionPanel { get => interactionPanel; set => interactionPanel = value; }
    public TextMeshProUGUI InteractionText { get => interactionText; set => interactionText = value; }

    //-----------------------------------------------------

    private void Awake()
    {
        //Asignamos instancia
        Instance = this;

        //Obtenemos referencia al AudioSource
        mAudioSource = GetComponent<AudioSource>();

        //Obtenemos referencia a la transicion
        objTransicion = transform.Find("Transition");
    }

    //---------------------------------------------------------
    //---------------------------------------------------------

    private void PosicionarTransicionDetras()
    {
        objTransicion.SetAsFirstSibling();
    }

    //---------------------------------------------------------

    private void PosicionarTransicionDelante()
    {
        objTransicion.SetAsLastSibling();
    }

    //---------------------------------------------------------

    //---------------------------------------------------------

    public void MoverArriba()
    {
        Manager2D.Instance.MoveInput = Vector3.up;
    }

    public void MoverAbajo()
    {
        Manager2D.Instance.MoveInput = Vector3.down;
    }

    public void MoverIzquierda()
    {
        Manager2D.Instance.MoveInput = Vector3.left;
    }

    public void MoverDerecha()
    {
        Manager2D.Instance.MoveInput = Vector3.right;
    }

    public void Detenerse()
    {
        Manager2D.Instance.MoveInput = Vector3.zero;
    }

    public void BtnDialogClick()
    {
        if (Manager2D.Instance.ObjetoDialogo != null)
        {
            //Llamamos a la funcion de DialogoOprimido desde el Objeto dueño del dialogo
            Manager2D.Instance.ObjetoDialogo.GetComponent<Dialog>().DialogoOprimido();
            //Reproducimos Sonido de Pokemon
            mAudioSource.PlayOneShot(clipClicks, 0.5f);
        }
    }

    public void BtnObservationClick()
    {
        if (Manager2D.Instance.ObjetoObservacion != null)
        {
            //Llamamos a la funcion de DialogoOprimido desde el Objeto dueño del dialogo
            Manager2D.Instance.ObjetoObservacion.GetComponent<Observation>().ObservacionOprimida();
            ////Reproducimos Sonido de Pokemon
            mAudioSource.PlayOneShot(clipClicks, 0.5f);
        }
    }

    //-------------------------------------------------------------------------------------------------------
    public void BtnManipulationClick()
    {
        if (Manager2D.Instance.ObjetoManipulacion != null)
        {
            //Reproducimos Sonido de Manipulacion
            mAudioSource.PlayOneShot(clipManipulacion, 0.5f);
        }
    }

    public void BtnManipulationDown()
    {
        if (Manager2D.Instance.ObjetoManipulacion != null)
        {
            //Llamamos a la funcion de ManipulacionOprimida desde el Objeto dueño del dialogo
            Manager2D.Instance.ObjetoManipulacion.GetComponent<Manipulation>().ManipulacionOprimida();
        }
    }

    public void BtnManipulationUp()
    {
        if (Manager2D.Instance.ObjetoManipulacion != null)
        {
            //Llamamos a la funcion de Convertir a Kinematico
            Manager2D.Instance.ObjetoManipulacion.GetComponent<Manipulation>().ConvertirAKinematico();
        }
    }

    //--------------------------------------------------------------------------------------------------------


    public void BtnComentarioDronClick()
    {
        //Si el Dron aun no ha mepezado a hablar
        if (!Manager2D.Instance.Dron.GetComponent<DronCommentsController>().DronEmpezoAHablar)
        {
            //Reproducimos sonido del Dron e invocamos a la funcion
            mAudioSource.PlayOneShot(clipsDron[UnityEngine.Random.Range(0, 5)], 0.5f);
            Manager2D.Instance.Dron.GetComponent<DronCommentsController>().BtnComentarioDronOprimido();
        }
        else
        {
            //Reproducimos sonido de Click(Pokemon) e invocamos a la funcion
            mAudioSource.PlayOneShot(clipClicks, 0.5f);
            Manager2D.Instance.Dron.GetComponent<DronCommentsController>().BtnComentarioDronOprimido();
        }
    }


    

        //----------------------------------------------------------------------------------------------------------

        public void BtnEvento3DClick()
    {
        mAudioSource.PlayOneShot(clipEvento3D, 0.5f);
    }

    //---------------------------------------------------------------
    //---------------------------------------------------------------

    public void VolverAlMenu()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("MainMenu");
    }
}
