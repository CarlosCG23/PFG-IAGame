using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarManagerScript : MonoBehaviour
{
    public TextMeshProUGUI StarCountTMP;
    private int StarCount = 0;

    // Update is called once per frame
    void Update()
    {
        StarCountTMP.text = StarCount.ToString();
    }

    public void StarAdd()
    {
        StarCount = StarCount + 1;  
    }
}
