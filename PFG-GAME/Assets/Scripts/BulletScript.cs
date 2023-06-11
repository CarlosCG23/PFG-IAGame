using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float Speed = 3f;
    private Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene el componente de rigidbody2d (Bala)
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // la velocidad de la bala es direccion * velocidad
        rb2d.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        // Seteas la direccion en la que va a ir la bala
        Direction = direction;
    }

    public void DestroyBullet()
    {
        // destruye el objeto bala
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // obtiene el collider de colision de la bala con jugador y enemigo
        PlayerMove player = collision.GetComponent<PlayerMove>();
        EnemyScript enemy = collision.GetComponent<EnemyScript>();

        // si el player existe, llamara a la funcion hit, que le quitara
        // una vida al jugador y destruira la bala
        if (player != null) 
        {
            player.Hit();
            DestroyBullet();
        }
        // si el Enemigo existe, llamara a la funcion hit, que le quitara
        // una vida al enemigo y destruira la bala
        if (enemy != null)
        {
            enemy.Hit();
            DestroyBullet();
        }

        // si la collision se hace con un objeto con el tag de 
        // Ground, es decir el suelo, directamente se destruira la bala
        if (collision.CompareTag("Ground"))
        {
            DestroyBullet();
        }
    }
}
