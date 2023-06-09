using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public TextMeshProUGUI EnemyCountTMP;
    private int EnemyCount;
    private int EnemyTot;
    private int controller = 0;
    public GameObject starManagerObject;
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        EnemyTot = transform.childCount;

        // Acceder al atributo "vida" de cada hijo
        for (int i = 0; i < EnemyTot; i++)
        {
            Transform hijo = transform.GetChild(i);
            hijo.GetComponent<EnemyScript>().Health = Health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = EnemyTot - transform.childCount;
        EnemyCountTMP.text = EnemyCount.ToString();

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
