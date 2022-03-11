using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOLLOW_RUTE_DERROTA : MonoBehaviour
{
    private GameManager GmScript;

    //PUNTOS DE RUTA A SEGUIR
    public Transform[] PuntosDeRuta;
    public int TotalPoints;
    public int DestinoActual;

    //VELOCIDAD DE MOVIMIENTO
    public float Speed = 30;

    //SE SEGUIRA LA RUTA UNO DETRAS DEL OTRO
    void Start()
    {
        transform.position = PuntosDeRuta[0].position;
        DestinoActual = 1;
        transform.LookAt(PuntosDeRuta[DestinoActual].position);
    }

    //AL ACABAR LA RUTA SE REINICIARA DESDE ELPRIMER NUMERO
    void Update()
    {
        if (Vector3.Distance(transform.position, PuntosDeRuta[DestinoActual].position) < 0.1f)
        {
            DestinoActual++;
            if (DestinoActual == TotalPoints)
            {
                DestinoActual = 0;
            }
            transform.LookAt(PuntosDeRuta[DestinoActual].position);
        }

        transform.position = Vector3.MoveTowards(transform.position, PuntosDeRuta[DestinoActual].position, Speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Debug.Log("11");
        GmScript.DRACO_COUNT--;
    }
}
