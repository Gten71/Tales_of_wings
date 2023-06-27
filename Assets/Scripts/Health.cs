using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarBehaviour healthBar;

    private void Start()
    {
        currentHealth = maxHealth;

        // Find the HealthBarBehaviour component in the children of this enemy
        healthBar = GetComponentInChildren<HealthBarBehaviour>();

        if (healthBar != null)
        {
            // Set the initial health values on the health bar
            healthBar.SetHealth(currentHealth, maxHealth);
        }
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

