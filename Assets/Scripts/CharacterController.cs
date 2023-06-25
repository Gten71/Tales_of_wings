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




    public float moveSpeed = 5f;
    public Joystick joystick;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.velocity = movement * moveSpeed;

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
        // Направляем персонажа на врага
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Shoot()
    {
        // Создаем снаряд и задаем ему направление и скорость
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = firePoint.right * bulletSpeed;
     //   Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            // Передаем урон снаряда врагу
            bulletComponent.damage = bulletDamage;
           // bulletComponent.SetDamage(bulletDamage);
        }

        currentAmmo--;
    }
    

}

