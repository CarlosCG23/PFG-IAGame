using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    // VARIABLES GLOBALES
    public TextMeshProUGUI PrizeCountTMP;
    private int PrizeCount;
    private int PrizeTot;
    private int controller = 0;
    public GameObject starManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        // obtiene todos los hijos del objeto PrizeManager
        PrizeTot = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Esto es para que el contador empiece en 0 y vaya sumando desde ahí
        PrizeCount = PrizeTot - transform.childCount + 4;

        // Escribe el el canvas el numero de premios que consigue el jugador
        PrizeCountTMP.text = PrizeCount.ToString();
        
        // en caso de que el jugador obtenga todos los premios se le sumará una estrella
        // poongo un controlador para que solo entre una vez 
        if ( PrizeCount == PrizeTot && controller == 0 )
        {
            // obtiene el script del objeto y si existe lo llama para sumar una estrella
            StarManagerScript starManagerScript = starManagerObject.GetComponent<StarManagerScript>();
            if (starManagerScript != null)
            {
                starManagerScript.StarAdd();
            }
            controller = 1;
        }
    }
}
