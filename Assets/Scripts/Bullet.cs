using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float destroyDelay; // ����� �������� ����� ������������ �������

    private void Start()
    {
        // ��������� ������ ������� ����� ������������ �������
        StartCoroutine(DestroyAfterDelayCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);

            // �������� �������� ������� ��������
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

            // �������� �������� ������� �������� �����
            HealthBarBoss bossHealthBar = collision.gameObject.GetComponentInChildren<HealthBarBoss>();
            if (bossHealthBar != null)
            {
                bossHealthBar.SetHealth(bossHealth.currentHealth, bossHealth.maxHealth);
            }
        }

        // ���� ������ ����� �� ���-��, ���������� ��� ����������
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterDelayCoroutine()
    {
        yield return new WaitForSeconds(destroyDelay);

        // ���������� ������ ����� ���������� �������
        Destroy(gameObject);
    }
}
