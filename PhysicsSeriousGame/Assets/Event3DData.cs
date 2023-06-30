using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3DData : MonoBehaviour 
{
    public int IDEvento;
    [SerializeField, TextArea(3, 5)] private string textoObjetivo;
    [SerializeField, TextArea(3, 5)] private List<string> comentariosDron;

    //CONSTRUCTORES - - - - - - - - - - - - - - - - -
    public string TextoObjetivo { get => textoObjetivo; set => textoObjetivo = value; }
    public List<string> ComentariosDron { get => comentariosDron; set => comentariosDron = value; }
}
