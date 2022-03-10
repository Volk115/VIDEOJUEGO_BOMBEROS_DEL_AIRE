using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTATE_ELICE_DERROTA : MonoBehaviour
{
    //VELOCIDAD DE ROTACION
    private float rotateSpeed = 40;

    //ROTACION CONSTANTE
    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * rotateSpeed);
    }
}
