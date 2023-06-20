using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoGameScript : MonoBehaviour
{
    private int dificultCalculator;
    // Start is called before the first frame update
    void Start()
    {
        dificultCalculator = DifficultyManager.difficulty;
        WinScript.gameStatus = -1;

        Invoke("GameResolution", 1f);
    }

    private void GameResolution()
    {
        // Generar un número aleatorio entre 0 y 1, redondeado a 0 o 1
        int randomNumberWIN = Mathf.RoundToInt(Random.Range(0f, 1f));

        // Imprimir el número aleatorio en la consola
        // Debug.Log("Número aleatorio 0 1: " + randomNumberWIN);

        // Generar un número aleatorio entre 0 y 1, redondeado a 0 o 1
        int randomNumberSTAR = Mathf.RoundToInt(Random.Range(1f, 3f));

        // Imprimir el número aleatorio en la consola
        // Debug.Log("Número aleatorio 0 1 2: " + randomNumberSTAR);

        if (randomNumberWIN == 0)
        {
            //Debug.Log("Has Ganado");
            WinScript.gameStatus = 0;
            StarManagerScript.StarCount = randomNumberSTAR;
            //Debug.Log("El número de estrellas obtenido es: " + randomNumberSTAR);
            Invoke("LoadScene", 1f);
            /*
            if (randomNumberSTAR == 3)
            {
                dificultCalculator = dificultCalculator + 1;
                if (dificultCalculator >= 2)
                {
                    DifficultyManager.difficulty = 2;
                    Invoke("LoadScene", 1f);
                }
                else
                {
                    DifficultyManager.difficulty = dificultCalculator;
                    Invoke("LoadScene", 1f);
                }
            }
            else if (randomNumberSTAR < 3)
            {
                Invoke("LoadScene", 1f);
            }
            */
        }
        else if (randomNumberWIN == 1)
        {
            //Debug.Log("Has Perdido");
            WinScript.gameStatus = 1;
            StarManagerScript.StarCount = 0;
            Invoke("LoadScene", 1f);
            /*
            dificultCalculator = dificultCalculator - 1;
            if (dificultCalculator <= 0)
            {
                DifficultyManager.difficulty = 0;
                Invoke("LoadScene", 1f);
            }
            else
            {
                DifficultyManager.difficulty = dificultCalculator;
                Invoke("LoadScene", 1f);
            }
            */
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
        //Invoke("Start", 1f);
    }
}
