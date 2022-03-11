using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    void Update()
    {
        //CON LA TECLA ESPACIO SE ACCEDE AL JUEGO
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("VIDEOJUEGO");
        }

        //CON LA TECLA ESCAPE SE SLAE DEL JUEGO
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}
