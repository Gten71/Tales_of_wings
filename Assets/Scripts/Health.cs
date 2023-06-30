using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarBehaviour healthBar;
    public GameObject itemPrefab;
    public Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
        healthBar.gameObject.SetActive(false);
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
            healthBar.gameObject.SetActive(true);
        }
        if (healthBar != null)
        {
            // Update the health bar with the new health values
            healthBar.SetHealth(currentHealth, maxHealth);
            animator.SetBool("isTakeDamage", true);

            // ��������� �������� ��� ������������ �� �������� "Idle" ����� ������������ �������� ��������
            StartCoroutine(Damage());
        }


    }
    private IEnumerator Damage()
    {
        // ����, ���� ����������� �������� ��������
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // ����������� �������� "Idle"
        animator.SetBool("isTakeDamage", false);


    }

    private IEnumerator Dide()
    {
        // ����, ���� ����������� �������� ��������
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // ����������� �������� "Idle"
        animator.SetBool("isDead", false);
        GameObject itemObj = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Die()
    {
        animator.SetBool("isDead", true);

        // ��������� �������� ��� ������������ �� �������� "Idle" ����� ������������ �������� ��������
        StartCoroutine(Dide());

    }
}



