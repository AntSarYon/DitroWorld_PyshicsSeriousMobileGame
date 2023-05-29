using UnityEngine;

public class UI2DController : MonoBehaviour
{
    //Referencia al Objeto de UI de Transicion
    private Transform objTransicion;

    //-----------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia a la transicion
        objTransicion = transform.Find("Transition");
    }

    //---------------------------------------------------------

    private void PosicionarTransicionDetras()
    {
        objTransicion.SetAsFirstSibling();
    }

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

    public void VolverAlMenu()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("MainMenu");
    }
}
