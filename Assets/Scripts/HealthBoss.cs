using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarBoss healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        if (healthBar != null)
        {
            // Update the health bar with the new health values
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
