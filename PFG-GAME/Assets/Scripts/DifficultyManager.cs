using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public TextMeshProUGUI DifficultyTMP;
    public GameObject enemyManagerObject;

    //public GameObject Object;
    void Start()
    {
        DifficultyTMP.text = "Easy";
        EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
        enemyManagerScript.Health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
            enemyManagerScript.Health = 3;
            DifficultyTMP.text = "Easy";
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
            enemyManagerScript.Health = 5;
            DifficultyTMP.text = "Menium";
        }
        else if(Input.GetKeyDown(KeyCode.J))
        {
            EnemyManagerScript enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
            enemyManagerScript.Health = 9;
            DifficultyTMP.text = "Hard";
        }
    }
}
