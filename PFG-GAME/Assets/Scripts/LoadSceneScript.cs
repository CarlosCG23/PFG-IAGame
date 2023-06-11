using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // dependiendo de la tecla a la que le pulses cambiará la dificultad
        // a la funcion de cambiar la dificultad se le pasa 0,1 ó 2
        // para que cambie la dificultad
        // probablemente esto cambie cuando introduzca la red neuronal
        // en caso de algun bug se pulsa la R para que se pueda reiniciar el nivel
        if (Input.GetKeyDown(KeyCode.G))
        {
            CargarEscenaConDificultad(0);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            CargarEscenaConDificultad(1);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            CargarEscenaConDificultad(2);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void CargarEscenaConDificultad(int difficulty)
    {
        // Cargar la escena siguiente
        SceneManager.LoadScene("SampleScene");

        // Guardar la dificultad en una variable estática el objeto tambien es estatico
        // dependiendo de lo que le entre a la funcion la dificultad cambiara a Facil, Medio o Dificil
        DifficultyManager.difficulty = difficulty;
    }
}
