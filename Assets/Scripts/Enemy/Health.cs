using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarBehaviour healthBar;
    public GameObject itemPrefab;
    public GameObject secondItemPrefab;
    public Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
        healthBar.gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        if (healthBar != null)
        {
            // Обновляем хп с новым значением
            healthBar.SetHealth(currentHealth, maxHealth);
            healthBar.gameObject.SetActive(true);
        }
        if (healthBar != null)
        {
            // Обновляем хилбар
            healthBar.SetHealth(currentHealth, maxHealth);
            animator.SetBool("isTakeDamage", true);

            // Запускаем корутину для переключения на анимацию "Idle" после проигрывания анимации выстрела
            StartCoroutine(Damage());
        }


    }
    private IEnumerator Damage() // 
    {
        // Ждем, пока проиграется анимация выстрела
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Проигрываем анимацию "Idle"
        animator.SetBool("isTakeDamage", false);


    }

    private IEnumerator Dide()
    {
        // Ждем, пока проиграется анимация выстрела
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Проигрываем анимацию "Idle"
        animator.SetBool("isDead", false);
        GameObject itemObj = Instantiate(itemPrefab, transform.position, Quaternion.identity);

        GameObject secondItemObj = Instantiate(secondItemPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void Die()
    {
        animator.SetBool("isDead", true);

        // Запускаем корутину для переключения на анимацию "Idle" после проигрывания анимации выстрела
        StartCoroutine(Dide());

    }
}



