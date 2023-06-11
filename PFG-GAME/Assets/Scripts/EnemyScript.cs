using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // VARIABLES GLOBALES
    public GameObject Player;
    private float distance;
    private float LastShoot;
    public GameObject BulletPrefab;
    public int Health;
    private Vector3 ForwardDirection;
    public TextMeshProUGUI HealthEnemyTMP;
    public LayerMask playerLayer;

    // Update is called once per frame
    private void Update()
    {
        // pondrá la vida del enemigo en todo momento
        HealthEnemyTMP.SetText(Health.ToString());

        // si el jugador no existe no se hará nada del codigo siguiente
        if (Player == null)
        {
            return;
        }

        // obtener la direccion a la que tiene que mirar el enemigo
        // dependiendo de donde esta el jugador
        Vector3 direction = Player.transform.position - transform.position;

        // si la direccion es mayor o igual que 0 entonces la posicion en la que mira
        // el enemigo sera la normal pero si no mirará hacia el lado contrario
        // se hace modificando la escala del sprite (del objeto)
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            HealthEnemyTMP.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            HealthEnemyTMP.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        }

        // Obtiene la direccion hacia delande de donde esta mirando el enemigo para
        // tirar un rayo en esa direccion, compueba el hit en cada momento
        ForwardDirection = transform.localScale - new Vector3(0.0f, 1.0f, 1.0f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, ForwardDirection, 1.35f, playerLayer);

        // si hay hit y el tiempo del ultimo disparo es mayor entonces el enemigo disparará 
        if (Time.time > LastShoot + 0.65f && hit.collider != null)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    // funcion para que el enemigo dispare, igual que la del player
    private void Shoot()
    {
        // La direccion se comprueba por el la escala del objeto
        // si la componente x de la escala es 1 entoces disparara para la derecha
        // en caso contrario disparará para de izquierda
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        // Se instancia el prefab bala en la direccion en la que esta mirando el enemigo
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);

        // llama a la funcion para que la bala se mueva
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    // funcion para que si le dan al enemigo a este se le baje una vida
    // es igual que la del player, aunque aqui solo se elimina el objeto
    public void Hit()
    {
        Health = Health - 1;
        if (Health <= 0)
        {
            HealthEnemyTMP.text = "0";
            Destroy(gameObject);
        }
    }
}
