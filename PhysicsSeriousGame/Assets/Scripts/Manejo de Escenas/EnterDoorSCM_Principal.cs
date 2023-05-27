using UnityEngine;

public class EnterDoorSCM_Principal : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScenesManager.Instance.SolicitarCambioDeEscena("3DTutorial");
        }
    }
}
