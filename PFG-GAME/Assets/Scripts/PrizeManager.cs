using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    public TextMeshProUGUI PrizeCountTMP;
    private int PrizeCount;
    private int PrizeTot;
    private int controller = 0;
    public GameObject starManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        PrizeTot = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        PrizeCount = PrizeTot - transform.childCount;
        PrizeCountTMP.text = PrizeCount.ToString();
        
        if ( PrizeCount == PrizeTot && controller == 0 )
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
