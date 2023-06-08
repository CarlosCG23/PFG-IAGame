using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.GetComponent<PlayerMove>();

        if (collision.gameObject.CompareTag("Player"))
        {
            player.Life();
            Destroy(gameObject);
        }
    }
}
