using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatPosition : MonoBehaviour
{
    private Vector2 posInicial;
    private float anchoRepeticion;

    void Start()
    {
        posInicial = transform.position;
        anchoRepeticion = GetComponent<BoxCollider2D>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < posInicial.x - anchoRepeticion)
        {
            transform.position = posInicial;
        }
    }
}
