using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
     public Transform target; // ������ �� ������-�����
    public GameObject bulletPrefab; // ������ �������
    public Transform firePoint; // �����, ������ ����� ������� ������
    public float bulletSpeed = 10f; // �������� �������
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

        // ��������� ����������� ��� �������� ��������� �����
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
        // ���������� ��������� �� �����
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Shoot()
    {
        // ������� ������ � ������ ��� ����������� � ��������
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = firePoint.right * bulletSpeed;
     //   Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            // �������� ���� ������� �����
            bulletComponent.damage = bulletDamage;
           // bulletComponent.SetDamage(bulletDamage);
        }

        currentAmmo--;
    }
    

}

