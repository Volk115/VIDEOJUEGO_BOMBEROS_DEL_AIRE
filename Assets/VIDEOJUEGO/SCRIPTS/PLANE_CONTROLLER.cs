using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLANE_CONTROLLER : MonoBehaviour
{
    private GameManager GMScript;
    //VELOCIDAD LINEAL
    public float speed = 50;

    //LIMITES
    private float rightlim = -350;
    private float leftlim = 350;
    private float backlim = 350;
    private float forwardlim = -350;
    private float uplim = 300;

    //VELOCIDAD DE ROTACION
    private float turnspeed = 60;
    private float horizontalInput;
    private float verticalInput;

    //PROYECTIL
    public GameObject proyectil;
    public GameObject barril;
    public GameObject positionBarril;

    //EFECTOS DE SONIDO
    private AudioSource playerAudioSource;

    public AudioClip balistaClip;
    public AudioClip bombaClip;

    //GAMEOVER
    public bool gameOver;

    //SE TARDARA UN CIERTO TIEMP PARA VOLVER A DISPARAR
    private bool canShotBalista = true;
    private bool canShotBarril = true;
    private float barrilcoldown = 6f;
    private float balistacoldown = 3f;

    //SI COLISIONA, MUERE
    void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("SUELO")|| otherCollider.gameObject.CompareTag("DRACO")|| otherCollider.gameObject.CompareTag("FUEGO"))
        {
            PERSISTENCE_DATA.sharedInstance.DRACO_COUNT_PD = GMScript.DRACO_COUNT;
            PERSISTENCE_DATA.sharedInstance.FUEGO_COUNT_PD = GMScript.FUEGO_COUNT;

            gameOver = true;
            Destroy(gameObject);
            Debug.Log("PRUEBA");
            SceneManager.LoadScene("DERROTA");
        }
    }

    //APARECE EN LA POSICION:
    void Start()
    {
        GMScript = FindObjectOfType<GameManager>();
        playerAudioSource = GetComponent<AudioSource>();
        transform.position = new Vector3(330, 160, 0);
    }

    void Update()
    {
        if (!gameOver)
        {
            //VELOCIDAD CONSTANTE HACIA ADELANTE
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //ROTACION
            transform.Rotate(Vector3.up, turnspeed * Time.deltaTime * horizontalInput);
            transform.Rotate(Vector3.left, turnspeed * Time.deltaTime * verticalInput);

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //USO DE LA ROTACION
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.forward, turnspeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.back, turnspeed * Time.deltaTime);
            }

            //USO DE PROYECTILES
            if (Input.GetKeyDown(KeyCode.Mouse0) && canShotBalista == true)
            {
                StartCoroutine(balistaTimer());
                Instantiate(proyectil, transform.position, gameObject.transform.rotation);
                playerAudioSource.PlayOneShot(balistaClip, 1);
            }

            if (Input.GetKeyDown(KeyCode.Space) && canShotBarril == true)
            {
                StartCoroutine(barrilTimer());
                Instantiate(barril, positionBarril.transform.position, gameObject.transform.rotation);
                playerAudioSource.PlayOneShot(bombaClip, 1);
            }
        }

        //LIMITES
        if(transform.position.z >= backlim)
        { transform.position = new Vector3(transform.position.x, transform.position.y, backlim); }
        
        if(transform.position.z <= forwardlim)
        { transform.position = new Vector3(transform.position.x, transform.position.y, forwardlim); }
        
        if(transform.position.x >= leftlim)
        { transform.position = new Vector3(leftlim, transform.position.y, transform.position.z); }
        
        if(transform.position.x <= rightlim)
        { transform.position = new Vector3(rightlim, transform.position.y, transform.position.z); }
        
        if(transform.position.y >= uplim)
        { transform.position = new Vector3(transform.position.x, uplim, transform.position.z); }
    }

    //1-NO PUEDE DISPARAR 2-ESPERA UN TIEMPO 3-PUEDE DISPARAR
    public IEnumerator balistaTimer()
    {
        canShotBalista = false;
        yield return new WaitForSeconds(balistacoldown);
        canShotBalista = true;
    }

    //1-NO PUEDE DISPARAR 2-ESPERA UN TIEMPO 3-PUEDE DISPARAR
    public IEnumerator barrilTimer()
    {
        canShotBarril = false;
        yield return new WaitForSeconds(barrilcoldown);
        canShotBarril = true;
    }
}
