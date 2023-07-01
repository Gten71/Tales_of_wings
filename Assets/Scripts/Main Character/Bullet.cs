using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float destroyDelay; // ¬рем€ задержки перед уничтожением снар€да

    private void Start()
    {
        // «апускаем отсчет времени перед уничтожением снар€да
        StartCoroutine(DestroyAfterDelayCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);

            // ќбновите значение полоски здоровь€
            HealthBar healthBar = collision.gameObject.GetComponentInChildren<HealthBar>();
            if (healthBar != null)
            {
                healthBar.SetHealth(health.currentHealth, health.maxHealth);
            }
        }

        HealthBoss bossHealth = collision.gameObject.GetComponent<HealthBoss>();
        if (bossHealth != null)
        {
            bossHealth.TakeDamage(damage);

            // ќбновите значение полоски здоровь€ босса
            HealthBarBoss bossHealthBar = collision.gameObject.GetComponentInChildren<HealthBarBoss>();
            if (bossHealthBar != null)
            {
                bossHealthBar.SetHealth(bossHealth.currentHealth, bossHealth.maxHealth);
            }
        }

        // ≈сли снар€д попал во что-то, уничтожаем его немедленно
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterDelayCoroutine()
    {
        yield return new WaitForSeconds(destroyDelay);

        // ”ничтожаем снар€д после указанного времени
        Destroy(gameObject);
    }
}
