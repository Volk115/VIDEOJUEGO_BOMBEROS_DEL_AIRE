using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DETECT_COLISIONS : MonoBehaviour
{
    //PARTICULAS DE AGUA
    public GameObject AGUA;

    //SE LLAMA AL GAME MANAGER
    public GameManager GameManagerScript;

    //PARTICULAS DE EXPLOSION
    public ParticleSystem explosionParticleSystem;

    //CUANDO COLISIONA
    void OnCollisionEnter(Collision otherCollider)
    {
        //CONTRA OBJETOS CON LA TAG FUEGO
        if (otherCollider.gameObject.CompareTag("FUEGO"))
        {
            if (!gameObject.CompareTag("PLAYER"))
            {
                Instantiate(AGUA, transform.position, gameObject.transform.rotation);
            }

            Destroy(otherCollider.gameObject);
            GameManagerScript.FUEGO_COUNT -= 1;
        }

        //CONTRA OBJETOS CON LA TAG DRACO
        if (otherCollider.gameObject.CompareTag("DRACO"))
        {
            Instantiate(explosionParticleSystem, otherCollider.transform.position, gameObject.transform.rotation);
            Destroy(otherCollider.gameObject);
        }

        //CONTRA OBJETOS CON LA TAG SUELO
        if (otherCollider.gameObject.CompareTag("SUELO"))
        {
            if (!gameObject.CompareTag("PLAYER"))
            {
                Instantiate(AGUA, transform.position, gameObject.transform.rotation);
            }
        }
        
        //SE DESTRUIRA EL OBJETO
        Destroy(gameObject);
    }

    //EL JUGADOR SE DESTRUIRA SI PIERDE
    void Start()
    {
        GameManagerScript = FindObjectOfType<GameManager>();

        if (!gameObject.CompareTag("PLAYER"))
        {
            Destroy(gameObject, 5);
        }
    }
}
