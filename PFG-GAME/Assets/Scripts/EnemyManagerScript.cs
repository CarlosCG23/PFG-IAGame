using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public TextMeshProUGUI EnemyCountTMP;
    private int EnemyCount;
    private int EnemyTot;

    // Start is called before the first frame update
    void Start()
    {
        EnemyTot = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = EnemyTot - transform.childCount;
        EnemyCountTMP.text = EnemyCount.ToString();
    }
}
