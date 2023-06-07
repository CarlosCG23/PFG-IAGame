using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float Speed = 15f;
    private Vector2 Direction;
    private float DestroyBulletTime = 70f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        DestroyBulletTime--;

        if (DestroyBulletTime == 0)
        {
            DestroyBullet();
            DestroyBulletTime = 0;
        }
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
}
