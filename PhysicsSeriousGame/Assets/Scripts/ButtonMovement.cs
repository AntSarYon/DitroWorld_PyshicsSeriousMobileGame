using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    public void MoverHaciaArriba()
    {
        player.Translate(Vector2.up * 1);
    }

    public void MoverHaciaAbajo()
    {
        player.Translate(Vector2.down * 1);
    }

    public void MoverHaciaIzquierda()
    {
        player.Translate(Vector2.left * 1);
    }

    public void MoverHaciaDerecha()
    {
        player.Translate(Vector2.right * 1);
    }
}