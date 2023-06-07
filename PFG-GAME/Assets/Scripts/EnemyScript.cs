using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;
    private float distance;
    private float LastShoot;
    public GameObject BulletPrefab;
    private int Health = 3;

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        { 
            return; 
        }

        Vector3 direction = Player.transform.position - transform.position;

        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
        }

        distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.5f)
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
            Destroy(gameObject);
        }
    }
}
