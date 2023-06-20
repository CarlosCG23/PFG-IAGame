using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    // VARIABLES GLOBALES
    public TextMeshProUGUI EnemyCountTMP;
    private int EnemyCount;
    private int EnemyTot;
    private int controller = 0;
    public GameObject starManagerObject;
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        // obtiene todos los hijos del objeto
        EnemyTot = transform.childCount;

        // Acceder al atributo "vida" de cada hijo
        // y les modificas la vida uno a uno en base a como  
        // la ha modificado el difficultyManagerScript()
        for (int i = 0; i < EnemyTot; i++)
        {
            Transform hijo = transform.GetChild(i);
            hijo.GetComponent<EnemyScript>().Health = Health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // el contador empieza en 0 y este va aumentando
        EnemyCount = EnemyTot - transform.childCount + 4;

        // se escribe en el canvas del contador de enemigos eliminados
        EnemyCountTMP.text = EnemyCount.ToString();

        // si eliminas a todos los enemigos se sumará una estrella
        // llamando a la funcion que las suma
        // el controlador esta para que solo entre una vez
        if (EnemyCount == EnemyTot && controller == 0)
        {
            StarManagerScript starManagerScript = starManagerObject.GetComponent<StarManagerScript>();
            if (starManagerScript != null)
            {
                starManagerScript.StarAdd();
            }
            controller = 1;
        }
    }
}
