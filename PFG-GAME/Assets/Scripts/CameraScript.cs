using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // VARIABLES GLOBALES
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        // La camara sigue al jugador si este existe
        // Obtiene la posicion "x" e "y" del jugador y se posiciona ahí
        // la coordenada "y" de la camara se pone un poco más arriba
        // de ahi sumarle 0.35f
        if (Player != null)
        {
            Vector3 position = transform.position;
            position.x = Player.transform.position.x;
            position.y = Player.transform.position.y + 0.35f;
            transform.position = position;
        }
    }
}
