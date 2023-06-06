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

        //Debug.DrawRay(transform.position, Vector2.down * 1.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        // Si pulsa ESPACIO llama a la función
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
    }

    // Funcion para que el personaje salte
    private void Jump()
    {
        rb2d.AddForce(Vector2.up * JumpForce);
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
