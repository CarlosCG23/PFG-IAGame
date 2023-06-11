using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si la colision con el collider2d es con el player
        // entocnes el objeto se destruirá
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
