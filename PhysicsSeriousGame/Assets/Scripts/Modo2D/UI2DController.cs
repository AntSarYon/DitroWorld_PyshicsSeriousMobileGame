using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI2DController : MonoBehaviour
{
    //Variable de Instancia
    public static UI2DController Instance;

    //Referencia a Componentes
    private AudioSource mAudioSource;

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
        //Llamamos a la funcion de DialogoOprimido desde el Objeto dueño del dialogo
        Manager2D.Instance.ObjetoDialogo.GetComponent<Dialog>().DialogoOprimido();
    }

    //---------------------------------------------------------------
    //---------------------------------------------------------------

    public void VolverAlMenu()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("MainMenu");
    }
}
