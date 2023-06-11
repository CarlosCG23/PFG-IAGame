using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    // Funcion de colision del jugador con la vida para sumarle
    // a este una vida y que la vida desaparezca
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // obtiene el objeto del collider con el que colisiona la vida
        PlayerMove player = collision.GetComponent<PlayerMove>();

        // si la colision se hace con un collider con tag 
        // de player entonces se le sumará una vida de se destruira
        if (collision.gameObject.CompareTag("Player"))
        {
            // llamada a la funcion para sumar una vida
            player.Life();
            // destruccion del objeto
            Destroy(gameObject);
        }
    }
}
