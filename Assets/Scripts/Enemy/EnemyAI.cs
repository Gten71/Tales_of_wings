using System.Collections;
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
    //анимации
    public Animator animator;

    private bool isMirrored = false;

    private void Start()
    {
        enemyHealth = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        // Проверяем, есть ли текущий враг и персонаж
        if (target != null && transform != null)
        {
            // Проверяем расстояние между врагом и персонажем
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= attackRange)
            {
                // Враг находится в пределах атаки
                if (!isAttacking)
                {
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
    }

    private void MoveTowardsPlayer() // функция движения к персонажу 
    {
        if (target != null)
        { 
           
            animator.SetBool("isSleep", false);
            Vector3 direction = target.position - transform.position;
            if (direction.x > 0 && isMirrored)
            {
                FlipEnemy();
            }
            else if (direction.x < 0 && !isMirrored)
            {
                FlipEnemy();
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
           
        }

        
    }

    private void AttackPlayer() // функция нанесения урона игроку
    {
        CharacterController healthController = target.GetComponent<CharacterController>();
        if (healthController != null)
        {
            healthController.TakeDamage(damageAmount);

            animator.SetBool("isAtake", true);
            animator.SetBool("isMove", true);
            StartCoroutine(Atake());
        }
    }
    private IEnumerator Atake()
    {
        // Ждем, пока проиграется анимация выстрела
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Проигрываем анимацию "Idle"
        animator.SetBool("isAtake", false);

    }

    public void TakeDamage(int damage)
    {
        enemyHealth.TakeDamage(damage);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("isMove", true);
            target = collision.transform;
            isAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (target == collision.transform)
            {
                target = null;
                isAttacking = false;
                animator.SetBool("isMove", false);
            }
        }
    }

        private void FlipEnemy() // это добавлено просто что бы враги переворачивались на игрока
    {
        isMirrored = !isMirrored;
        transform.Rotate(0f, 180f, 0f);
    }
}
