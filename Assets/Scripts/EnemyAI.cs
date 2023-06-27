using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float attackRange = 2f;
    public int damageAmount = 10;

    private Transform target;
    private bool isAttacking = false;
    private Health enemyHealth;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth = GetComponent<Health>(); // Получаем компонент Health врага
    }

    private void Update()
    {
        // Проверяем расстояние между врагом и персонажем
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= attackRange)
        {
            // Враг находится в пределах атаки
            if (!isAttacking)
            {
                // Начинаем атаку
                isAttacking = true;
                AttackPlayer();
            }
        }
        else
        {
            // Враг должен приблизиться к персонажу
            isAttacking = false;
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        // Направляем врага на персонажа
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

    }

    private void AttackPlayer()
    {
        // Наносим урон персонажу
        CharacterController healthController = target.GetComponent<CharacterController>();
        if (healthController != null)
        {
            healthController.TakeDamage(damageAmount);
        }
    }

    public void TakeDamage(int damage)
    {
        // Враг получает урон
        enemyHealth.TakeDamage(damage);
    }

    private void Die()
    {
        // Обработка смерти врага
        Destroy(gameObject);
    }
}



