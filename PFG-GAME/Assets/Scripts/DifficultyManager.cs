using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public TextMeshProUGUI DifficultyTMP;
    public static int difficulty;
    public GameObject enemyManagerObject;

    //public GameObject Object;
    void Start()
    {
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

    
}
