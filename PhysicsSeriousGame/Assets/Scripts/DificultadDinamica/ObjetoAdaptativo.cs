using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoAdaptativo : MonoBehaviour
{
    [SerializeField] private List<AdaptiveObjectData> listaAdaptaciones;

    private void Start()
    {
        //Para cada data adaptativa en la lista
        foreach (AdaptiveObjectData dataAdap in listaAdaptaciones)
        {
            //Si al dificultad corresponde con la del GameManager
            if (dataAdap.Dificultad == GameManager.Instance.siguienteDificultad)
            {
                //Si el GameObject esta destinado a Aparecer
                if (dataAdap.Participa)
                {
                    //Adoptamos sus atributos (Si es que los tiene)
                    if (dataAdap.Peso != 0)
                    {
                        GetComponent<Rigidbody>().mass = dataAdap.Peso;
                    }
                    break;
                }

                //Si no participa en esta dificultad,
                else
                {
                    //Desactivamos el GameObject
                    gameObject.SetActive(false);
                    break;                
                }
            }
        }

    }


}
