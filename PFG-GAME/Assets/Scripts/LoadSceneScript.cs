using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public void CargarEscenaConDificultad(int difficulty)
    {
        // Cargar la escena siguiente
        SceneManager.LoadScene("SampleScene");

        // Guardar la dificultad en una variable estática o en algún mecanismo de comunicación entre escenas
        DifficultyManager.difficulty = difficulty;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
