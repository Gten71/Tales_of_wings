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
        enemyHealth = GetComponent<Health>(); // �������� ��������� Health �����
    }

    private void Update()
    {
        // ��������� ���������� ����� ������ � ����������
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= attackRange)
        {
            // ���� ��������� � �������� �����
            if (!isAttacking)
            {
                // �������� �����
                isAttacking = true;
                AttackPlayer();
            }
        }
        else
        {
            // ���� ������ ������������ � ���������
            isAttacking = false;
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        // ���������� ����� �� ���������
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

    }

    private void AttackPlayer()
    {
        // ������� ���� ���������
        CharacterController healthController = target.GetComponent<CharacterController>();
        if (healthController != null)
        {
            healthController.TakeDamage(damageAmount);
        }
    }

    public void TakeDamage(int damage)
    {
        // ���� �������� ����
        enemyHealth.TakeDamage(damage);
    }

    private void Die()
    {
        // ��������� ������ �����
        Destroy(gameObject);
    }
}



