using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float attackRange = 2f;
    public int damageAmount = 10;

    private Transform target;
    private bool isAttacking = false;
    private Health enemyHealth;
    private HealthBarBehaviour enemyHealthBar;
    private Rigidbody2D rb;

    private bool isMirrored = false; // ‘лаг, указывающий, нужно ли зеркально отражать врага

    private void Start()
    {
        enemyHealth = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        // ѕровер€ем, есть ли текущий враг и персонаж
        if (target != null && transform != null)
        {
            // ѕровер€ем рассто€ние между врагом и персонажем
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= attackRange)
            {
                // ¬раг находитс€ в пределах атаки
                if (!isAttacking)
                {
                    // Ќачинаем атаку
                    isAttacking = true;
                    AttackPlayer();
                }
            }
            else
            {
                // ¬раг должен приблизитьс€ к персонажу
                isAttacking = false;
                MoveTowardsPlayer();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            if (direction.x > 0 && isMirrored)
            {
                FlipCharacter();
            }
            else if (direction.x < 0 && !isMirrored)
            {
                FlipCharacter();
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }
    }

    private void AttackPlayer()
    {
        CharacterController healthController = target.GetComponent<CharacterController>();
        if (healthController != null)
        {
            healthController.TakeDamage(damageAmount);
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            target = collision.transform;
            isAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            target = null;
            isAttacking = false;
        }
    }

    private void FlipCharacter()
    {
        isMirrored = !isMirrored;
        transform.Rotate(0f, 180f, 0f);
    }
}
