using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBoss : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(true);
        slider.value = health;
        slider.maxValue = maxHealth;
    }
}
