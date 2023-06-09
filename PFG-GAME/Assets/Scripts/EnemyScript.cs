using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
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
        HealthEnemyTMP.SetText(Health.ToString());

        if (Player == null)
        {
            return;
        }

        Vector3 direction = Player.transform.position - transform.position;

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

        ForwardDirection = transform.localScale - new Vector3(0.0f, 1.0f, 1.0f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, ForwardDirection, 1.35f, playerLayer);
        //Debug.DrawRay(transform.position, ForwardDirection * 0.65f, Color.red);
        //distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (Time.time > LastShoot + 0.5f && hit.collider != null)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

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
