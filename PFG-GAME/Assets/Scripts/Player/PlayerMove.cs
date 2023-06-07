using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // VARIABLES GLOBALES
    private Rigidbody2D rb2d;
    private float Horizontal;
    private bool Grounded;
    private RaycastHit2D hit2D;
    public LayerMask groundLayer;
    public GameObject BulletPrefab;
    private float LastShoot;

    private float Speed = 8f;
    private float JumpForce = 800f;
    private float GravityForce = 20f;

    

    void Start()
    {   
        // Referenciando el objeto
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // +1 o -1 dependiendo de si pulsas A o D
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if(Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        //Debug.DrawRay(transform.position, Vector2.left * 0.6f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        // Si pulsa ESPACIO llama a la función
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    // Funcion para que el personaje salte
    private void Jump()
    {
        rb2d.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction; 
        if(transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f , Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        // Movimiento del personaja en el eje X
        rb2d.velocity = new Vector2(Horizontal * Speed, rb2d.velocity.y);
        if (!Grounded)
        {
            rb2d.AddForce(Vector2.down * GravityForce);
        }
    }
}
