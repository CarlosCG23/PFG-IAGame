using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float Speed = 2f;
    private Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.GetComponent<PlayerMove>();
        EnemyScript enemy = collision.GetComponent<EnemyScript>();

        if (player != null) 
        {
            player.Hit();
        }
        if (enemy != null)
        {
            enemy.Hit();    
        }

        DestroyBullet();
    }
}
