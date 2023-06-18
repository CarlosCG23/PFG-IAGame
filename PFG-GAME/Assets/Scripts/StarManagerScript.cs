using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarManagerScript : MonoBehaviour
{
    public TextMeshProUGUI StarCountTMP;
    public static int StarCount = 0;

    public void Start()
    {
        StarCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Escribirá en todo momento el numero de
        // estrellas que congia el jugador
        StarCountTMP.text = StarCount.ToString();
    }

    // Funcion para añadir una estrella al contado
    public void StarAdd()
    {
        StarCount = StarCount + 1;  
    }
}
