using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI2DController : MonoBehaviour
{
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
}
