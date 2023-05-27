using UnityEngine;

public class EnterDoorPlantilla2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScenesManager.Instance.SolicitarCambioDeEscena("2DLabPrincipal");
        }
    }
}
