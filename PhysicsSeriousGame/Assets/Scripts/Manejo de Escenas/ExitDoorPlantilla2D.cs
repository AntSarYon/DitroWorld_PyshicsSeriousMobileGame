using UnityEngine;

public class ExitDoorPlantilla2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Activamos el Flag y mostramos el icono de dialogo
            ScenesManager.Instance.SolicitarCambioDeEscena("2DLabOutside");
        }
    }
}
