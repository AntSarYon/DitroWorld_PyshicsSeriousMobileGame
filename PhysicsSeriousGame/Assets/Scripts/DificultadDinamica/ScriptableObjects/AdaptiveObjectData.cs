using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AdaptiveObjectData", menuName = "AdaptiveObjectData")]
public class AdaptiveObjectData : ScriptableObject
{
    [SerializeField] private NivelDeDificultad dificultad;

    [SerializeField] private bool participa;

    [SerializeField] private float peso = 0;
    [SerializeField] private float friccion = 0;

    [SerializeField] private Vector3 posicion = Vector3.zero;
    [SerializeField] private Quaternion rotacionQ = Quaternion.identity;
    [SerializeField] private Vector3 escala = Vector3.zero;

    public NivelDeDificultad Dificultad { get => dificultad; set => dificultad = value; }
    public float Peso { get => peso; set => peso = value; }
    public Vector3 Posicion { get => posicion; set => posicion = value; }
    public Quaternion RotacionQ { get => rotacionQ; set => rotacionQ = value; }
    public Vector3 Escala { get => escala; set => escala = value; }
    public float Friccion { get => friccion; set => friccion = value; }
    public bool Participa { get => participa; set => participa = value; }
}
