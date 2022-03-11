using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DERROTA : MonoBehaviour
{
    public TextMeshProUGUI D;
    public TextMeshProUGUI F;

    //CON LA TECLA ESPACIO SE VUELVE AL MENU
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MENU");
        }
    }

    private void Start()
    {
        D.text = $"X{PERSISTENCE_DATA.sharedInstance.DRACO_COUNT_PD}";
        F.text = $"X{PERSISTENCE_DATA.sharedInstance.FUEGO_COUNT_PD}";
    }
}
