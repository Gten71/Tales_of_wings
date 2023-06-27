using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float currentHealth, float maxHealth)
    {
        slider.gameObject.SetActive(true);
        slider.value = currentHealth;
        slider.maxValue = maxHealth;
    }

    public void UpdateHealth(float health)
    {
        slider.value = health;
    }

    public void HideHealthBar()
    {
        slider.gameObject.SetActive(false);
    }
}
