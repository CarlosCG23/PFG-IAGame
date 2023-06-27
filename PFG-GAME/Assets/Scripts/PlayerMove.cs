using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // VARIABLES GLOBALES
    private Rigidbody2D rb2d;
    private float Horizontal;
    private float Direction = 1.0f;
    private bool Grounded;
    public GameObject BulletPrefab;
    private float LastShoot;
    private int Health = 7;
    public TextMeshProUGUI HealthTMP;
    private Vector3 initialPosition;

    private float Speed = 1f;
    private float JumpForce = 175f;

    void Start()
    {   
        // Referenciando el objeto
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = rb2d.position;
    }

    private void Update()
    {
        // Pone el texto de la vida del jugador
        HealthTMP.text = Health.ToString();

        // +1 o -1 dependiendo de si pulsas A o D
        Horizontal = Input.GetAxisRaw("Horizontal");

        // Sirve para modificar la escala del jugador
        // hace que el sprite se invierta y asi "mire" para donde te mueves
        // Si vas hacia adenate, Horizontal = 1, componente x de la escala normal (1)
        // si vas hacia atras, Horizontal = -1, componente X de la escala invertida (-1)
        if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Direction = 1.0f;
        }
        else if(Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            Direction = -1.0f;
        }

        // Crea dos rayos uno delante y otro detras, uno se situa en el pie de delante y otro en el pie trasero
        // si notan colisión es que esta en el suelo y Grounded = true
        // obvia la colision con el player, para ello desactivar en Project Settings -> Queries Start In Colliders
        if (Physics2D.Raycast(transform.position - new Vector3(0.04f, 0.0f, 0.0f) * Direction, Vector3.down, 0.1f) || Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        // Si pulsa ESPACIO y esta en el suelo, gorunded = true
        // llama a la función para que el personaje salte
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }

        // Si pulsa El botón izquiedo del raton y
        // el tiempo de cooldown es mayor que desde el momento que se ha hecho el ultimo disparo + 0.25
        // es decir dispara cada 0.25
        // llama a la función disparo 
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    // Funcion para que el personaje salte
    // para el salto se añade una fuerza (JumpForce) en direccion hacia arriba
    private void Jump()
    {
        rb2d.AddForce(Vector2.up * JumpForce);
    }

    // Funcion para que el personaje dispare
    // esta instanciara una bala, la cual existe como prefab
    // y se instanciara en el centro del personaje un poco más adelante 
    // en la direccion en la que esta mirando el personaje
    private void Shoot()
    {
        Vector3 direction;
        // la componente X del localScale viene dada por Horizontal
        // es decir por la direccion en la que esta mirando el personaje
        if(transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        // el objeto bala se iguala al prefab instanciado en la posicion del personaje + direccion dodnde mira + un poco adelantado
        // con la rotacion del personaje
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.13f , Quaternion.identity);

        // obtienes el componente del script de la bala llamando a la funcion que definirá la direccion en la que va
        // a ir la bala, por eso le pasas la direccion
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    // Funcion donde mejor funcionan las fisicas
    // se utilizara para el moviemiento del personaje
    private void FixedUpdate()
    {
        // Movimiento del personaja en el eje X
        rb2d.velocity = new Vector2(Horizontal * Speed, rb2d.velocity.y);
    }

    // Funcion para que si le dan un golpe al personaje
    // la vida disminuye, tambien setea la vida del personaje en caso 
    // de que esta sea 0, destuye el objeto del personaje (muere) y reinicia la escena
    public void Hit()
    {
        Health = Health - 1;
        if (Health <= 0)
        {
            HealthTMP.text = "0";
            //Destroy(gameObject);
            GetComponent<SpriteRenderer>().enabled = false; 
            GetComponent<CapsuleCollider2D>().enabled = false;  
            
            WinScript.gameStatus = 1;
            
            Invoke("LoadScene", 0.2f);
            //SceneManager.LoadScene("SampleScene");
        }
    }

    // funcion para sumarle una vida al personaje
    // a este se le podrá sumar todas las vidas que obtenga durante 
    // el nivel
    public void Life()
    {
        Health = Health + 1;
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

