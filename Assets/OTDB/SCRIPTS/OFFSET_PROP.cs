using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OFFSET_PROP : MonoBehaviour
{
    //EL FUEGO APARECERA DE FORMA RANDOM
    public GameObject particlesFire;
    public GameObject[] offsetFire;
    private float timeSpawn = 5f;
    private int randomOffset;

    void Start()
    {
        InvokeRepeating("SpawnRandomTarget", timeSpawn, timeSpawn);
    }

    private void SpawnRandomTarget()
    {
        randomOffset = Random.Range(0, offsetFire.Length);
        Instantiate(particlesFire, offsetFire[randomOffset].transform.position,
            particlesFire.transform.rotation);

    }
    
}
