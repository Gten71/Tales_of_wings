using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);

            // Обновите значение полоски здоровья
            HealthBar healthBar = collision.gameObject.GetComponentInChildren<HealthBar>();
            if (healthBar != null)
            {
                healthBar.SetHealth(health.currentHealth);
            }
        }

        Destroy(gameObject);
    }
}


