using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    // VARIABLES GLOBALES
    public TextMeshProUGUI DifficultyTMP;
    public static int difficulty = 0;
    public GameObject enemyManagerObject;
    
    void Start()
    {
        // para que la aplicacion siga funcionanado en segundo plano
        Application.runInBackground = true;

        // controlador de dificultad, dependiendo de si la dificultad es facil media o dificil
        // este escribirá en que nivel esta y modificará la vida de los enemigos
        // llamando al atributo del script que pone la vida, al ser un objeto estatico esto solo cambiará 
        // dentro del juego mientras este esta corriendo
        if (difficulty == 0)
        {
            EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
            enemyManagerScript.Health = 3;
            DifficultyTMP.text = "Easy";
        }
        else if (difficulty == 1)
        {
            EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
            enemyManagerScript.Health = 5;
            DifficultyTMP.text = "Medium";
        }
        else if (difficulty == 2)
        {
            EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
            enemyManagerScript.Health = 9;
            DifficultyTMP.text = "Hard";
        }
    }
    /*
    private void Update()
    {
        // controlador de dificultad, dependiendo de si la dificultad es facil media o dificil
        // este escribirá en que nivel esta y modificará la vida de los enemigos
        // llamando al atributo del script que pone la vida, al ser un objeto estatico esto solo cambiará 
        // dentro del juego mientras este esta corriendo
        if (difficulty == 0)
        {
            EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
            enemyManagerScript.Health = 3;
            DifficultyTMP.text = "Easy";
        }
        else if (difficulty == 1)
        {
            EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
            enemyManagerScript.Health = 5;
            DifficultyTMP.text = "Medium";
        }
        else if (difficulty == 2)
        {
            EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
            enemyManagerScript.Health = 9;
            DifficultyTMP.text = "Hard";
        }
    }
    */
}
