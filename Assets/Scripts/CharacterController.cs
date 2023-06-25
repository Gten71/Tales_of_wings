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

    private void Start()
    {
        currentAmmo = maxAmmo;
    }
   


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"));
        {
            // При нажатии кнопки Fire1 (например, при касании экрана) наводимся на врага и стреляем
          //  LookAtTarget();
           // Shoot();
        }
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
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            // Передаем урон снаряда врагу
            bulletComponent.SetDamage(bulletDamage);
        }

        currentAmmo--;
    }
    

}

