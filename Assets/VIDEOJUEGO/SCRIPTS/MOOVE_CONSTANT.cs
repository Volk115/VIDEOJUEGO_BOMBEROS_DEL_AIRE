using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOOVE_CONSTANT : MonoBehaviour
{
    //VELOCIDAD LINEAL
    public float speed = 60;

    void Update()
    {
        //VELOCIDAD CONSTANTE HACIA ADELANTE
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
