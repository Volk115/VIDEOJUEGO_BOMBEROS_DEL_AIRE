using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //VALORES DE DRACO Y FUEGO
    public int FUEGO_COUNT = 0;
    public int DRACO_COUNT = 0;
    private float timerCount = 5.0f;
    public GameObject canvasText;

    //NOMBRE DEL CONTADOR
    public TextMeshProUGUI TEXTO_DRACO;
    public TextMeshProUGUI TEXTO_FUEGO;
    public int CONTADOR = 0;

    //SE RESTA 1 CADA VEZ QUE ELIMINAMOS UN DRACO O UN FUEGO
    void Update()
    {
        if(FUEGO_COUNT <= 0 && DRACO_COUNT <= 0)
        {
            canvasText.SetActive(true);
            timerCount -= Time.deltaTime;
        }

        //SI SE ACABAN LAS AMENAZAS SE VA AL MENU
        if (timerCount <= 0f)
        {
            SceneManager.LoadScene("MENU");
        }

        //EL NUMERO DE VECES QUE EL CONTADOR CUENTA
        TEXTO_DRACO.text = $"X{DRACO_COUNT}";
        TEXTO_FUEGO.text = $"X{FUEGO_COUNT}";
    }
    //CONTADOR DE DRACOS Y FUEGOS
    void Start()
    {
        DRACO_COUNT = GameObject.FindGameObjectsWithTag("DRACO").Length;
        FUEGO_COUNT = GameObject.FindGameObjectsWithTag("FUEGO").Length;
    }
}
