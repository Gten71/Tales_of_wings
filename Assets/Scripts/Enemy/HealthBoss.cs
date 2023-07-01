using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarBoss healthBar;
    public GameObject itemPrefab;
    public GameObject secondItemPrefab;
    public GameObject thridItemPrefab;
    public Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
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
            healthBar.SetHealth(currentHealth, maxHealth);
            animator.SetBool("isTakeDamage", true);

            // «апускаем корутину дл€ переключени€ на анимацию "Idle" после проигрывани€ анимации выстрела
            StartCoroutine(Damage());
        }


    }
    private IEnumerator Damage()
    {
        // ∆дем, пока проиграетс€ анимаци€ выстрела
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // ѕроигрываем анимацию "Idle"
        animator.SetBool("isTakeDamage", false);


    }
    private IEnumerator Dide()
    {
        // ∆дем, пока проиграетс€ анимаци€ выстрела
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // ѕроигрываем анимацию "Idle" у босса 
        animator.SetBool("isDead", false);
        GameObject itemObj = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        GameObject secondItemObj = Instantiate(secondItemPrefab, transform.position, Quaternion.identity);
        GameObject thridItemObj = Instantiate(thridItemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Die()
    {
        animator.SetBool("isDead", true);

        // «апускаем корутину дл€ переключени€ на анимацию "Idle" после проигрывани€ анимации выстрела
        StartCoroutine(Dide());

    }
}
