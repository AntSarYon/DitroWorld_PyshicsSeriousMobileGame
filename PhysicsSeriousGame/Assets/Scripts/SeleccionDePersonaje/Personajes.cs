using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nuevo Personaje", menuName ="Personaje")]
public class Personajes : ScriptableObject
{
    public GameObject personajeJugable;
    public Sprite imagen;
    public string nombre;
}
