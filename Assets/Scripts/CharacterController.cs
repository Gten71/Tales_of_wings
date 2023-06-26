using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Transform target; // Ссылка на объект-врага
    public GameObject bulletPrefab; // Префаб снаряда
    public Transform firePoint; // Точка, откуда будет выпущен снаряд
    public float bulletSpeed = 10f; // Скорость снаряда
    public int bulletDamage = 50;
    public int maxAmmo = 5;
    private int currentAmmo;
    private bool isShooting = false;
    public int maxHealth = 100;
    public int currentHealth;


    public float moveSpeed = 5f;
    public Joystick joystick;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    //анимации
    public Animator animator;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        currentAmmo = maxAmmo;
        currentHealth = maxHealth;


    }


    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.velocity = movement * moveSpeed;
        //анимации
        direction.x = movement.x;
        direction.y = movement.y;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        // Изменение направления при повороте джойстика влево
        if (horizontalInput < 0 && isFacingRight)
        {
            FlipCharacter();
        }
        else if (horizontalInput > 0 && !isFacingRight)
        {
            FlipCharacter();
        }


    }


    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    public bool HasAmmo()
    {
        return currentAmmo > 0;
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public void LookAtTarget()
    {
        // Направляем снаряды на врага, но не поворачиваем персонажа
        if (target != null)
        {
            Vector2 direction = target.position - firePoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }





    //public void Shoot()
    //{
    //    // Создаем снаряд и задаем ему направление и скорость
    //    // GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //    // Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
    //    // bulletRigidbody.velocity = firePoint.right * bulletSpeed;
    //    //   Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    //    if (target != null)
    //    {
    //        Vector2 direction = target.position - transform.position;
    //        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    }

    //    // Создание снаряда в точке FirePoint
    //    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //    Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

    //    // Направление движения снаряда - от FirePoint к врагу
    //    if (target != null)
    //    {
    //        Vector2 direction = target.position - firePoint.position;
    //        bulletRigidbody.velocity = direction.normalized * bulletSpeed;
    //    }


    //    Bullet bulletComponent = bullet.GetComponent<Bullet>();
    //    if (bulletComponent != null)
    //    {
    //        // Передаем урон снаряда врагу
    //        bulletComponent.damage = bulletDamage;
    //        // bulletComponent.SetDamage(bulletDamage);
    //    }

    //    currentAmmo--;
    //}
    public void Shoot()
    {
        // Проверяем, есть ли враг в зоне видимости
        if (target != null)
        {
            // Создаем снаряд и задаем ему направление и скорость
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Направление движения снаряда - от FirePoint к врагу
            Vector2 direction = target.position - firePoint.position;
            bulletRigidbody.velocity = direction.normalized * bulletSpeed;

            // Передаем урон снаряда врагу через компонент EnemyAI
            EnemyAI enemy = target.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }
        }
        currentAmmo--;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, является ли столкнувшийся объект врагом с тегом "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Устанавливаем врага в качестве текущей цели
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Проверяем, является ли столкнувшийся объект врагом с тегом "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Сбрасываем текущую цель, когда она выходит из зоны видимости
            target = null;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Проверка на смерть персонажа
        if (currentHealth <= 0)
        {
            Die();
        }


    }
    private void Die()
    {

    }

}
