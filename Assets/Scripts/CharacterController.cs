using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance;

    public string enemyTag = "Enemy"; // ��� �����
    public GameObject bulletPrefab; // ������ �������
    public Transform firePoint; // �����, ������ ����� ������� ������
    public float bulletSpeed = 10f; // �������� �������
    public int bulletDamage = 50;
    public int maxAmmo = 50;
    private int currentAmmo;
    public int maxHealth = 100;
    public int currentHealth;
    public Collider2D shootingArea;


    private bool isShooting = false; // ����, �����������, ���������� �� ��������
    private bool isBulletActive = false; // ����, �����������, ������� �� ������

    public float moveSpeed = 5f;
    public Joystick joystick;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    //��������
    public Animator animator;
    private Vector2 direction;
    private bool isShootingg = false;

    public Transform target; // ������ �� �������� �����

    private void Start()
    {
        Instance = this;
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

        //��������
        direction.x = movement.x;
        direction.y = movement.y;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);

        // ��������� ����������� ��� �������� ��������� �����
        if (horizontalInput < 0 && isFacingRight)
        {
            FlipCharacter();
        }
        else if (horizontalInput > 0 && !isFacingRight)
        {
            FlipCharacter();
        }

        // ���������, ���� �� ��������� ���� � ���� ���������
        FindNearestEnemy();

        // ���������� ������� �� �����, �� �� ������������ ���������
        LookAtTarget();
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

    public void SetCurrentAmmo(int ammo)
    {
        currentAmmo = ammo;
    }
    public void LookAtTarget()
    {
        // ���������� ������� �� �����, �� �� ������������ ���������
        if (target != null)
        {
            Vector2 direction = target.position - firePoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    public void StartShooting()
    {

        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    public void Shoot()
    {
        // ���������, ���� �� ���� � ���� ���������
        if (target != null && HasAmmo())
        {
            // ������� ������ � ������ ��� ����������� � ��������
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // ����������� �������� ������� - �� FirePoint � �����
            Vector2 direction = target.position - firePoint.position;
            bulletRigidbody.velocity = direction.normalized * bulletSpeed;

            // �������� ���� ������� ����� ����� ��������� EnemyAI
            StartCoroutine(DealDamageDelayed(bullet, bulletDamage));
            // ��������, ��������� �� ��� �������� 1
            if (!isShootingg)
            {
                // ����������� �������� ��������
                animator.SetBool("IsShooting", true);
                isShootingg = true;

                // ��������� �������� ��� ������������ �� �������� "Idle" ����� ������������ �������� ��������
                StartCoroutine(PlayIdleAfterShoot());
            }
            currentAmmo--;
        }
    }
    private IEnumerator PlayIdleAfterShoot()
    {
        // ����, ���� ����������� �������� ��������
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // ����������� �������� "Idle"
        animator.SetBool("IsShooting", false);
        isShootingg = false;
    }

    private IEnumerator DealDamageDelayed(GameObject bullet, int damage)
    {
        // ����, ���� ������ ��������� ����
        yield return new WaitUntil(() => bullet == null || !bullet.activeSelf);

        // ���� ������ ���������� � ��������� (������� �� ����), ������� ����
        if (bullet != null && !bullet.activeSelf)
        {
            EnemyAI enemy = target.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    //public void Shoot()
    //{
    //    // ���������, ���� �� ���� � ���� ���������
    //    if (target != null && HasAmmo())
    //    {
    //        // ������� ������ � ������ ��� ����������� � ��������
    //        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

    //        // ����������� �������� ������� - �� FirePoint � �����
    //        Vector2 direction = target.position - firePoint.position;
    //        bulletRigidbody.velocity = direction.normalized * bulletSpeed;

    //        // �������� ���� ������� ����� ����� ��������� EnemyAI
    //        EnemyAI enemy = target.GetComponent<EnemyAI>();
    //        if (enemy != null)
    //        {
    //            enemy.TakeDamage(bulletDamage);
    //        }

    //        currentAmmo--;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, �������� �� ������������� ������ ������ � ����� "Enemy"
        if (other.CompareTag(enemyTag))
        {
            // ������������� ����� � �������� ������� ����
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ���������, �������� �� ������������� ������ ������ � ����� "Enemy"
        if (other.CompareTag(enemyTag))
        {
            // ���������� ������� ����, ����� ��� ������� �� ���� ���������
            target = null;
        }
    }

    private void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
                                                                                        
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
            // ����������� �������� ��������
            animator.SetBool("TakeDamage", true);

            // ��������� �������� ��� ������������ �� �������� "Idle" ����� ������������ �������� ��������
            StartCoroutine(PlayIdleAfterDamage());

    }
    private IEnumerator PlayIdleAfterDamage()
    {
        // ����, ���� ����������� �������� ��������
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // ����������� �������� "Idle"
        animator.SetBool("TakeDamage", false);

    }

    private void Die()
    {

            // ����������� �������� ��������
            animator.SetBool("Life", false);

            // ��������� �������� ��� ������������ �� �������� "Idle" ����� ������������ �������� ��������
            StartCoroutine(PlayIdleAfterDie());
       
    }
    private IEnumerator PlayIdleAfterDie()
    {
        // ����, ���� ����������� �������� ��������
        yield return new WaitForSeconds(1.5f);

        // ����������� �������� "Idle"

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


