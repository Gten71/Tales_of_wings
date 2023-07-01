using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;

    private bool isHit = false;

    void Update()
    {
        if (isHit)
        {
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        }
    }

    public void SetHealth(float health, float maxHealth)
    {
        if (health < maxHealth)
        {
            isHit = true;
            slider.gameObject.SetActive(true);
            slider.value = health;
            slider.maxValue = maxHealth;
        }
        else
        {
            isHit = false;
            slider.gameObject.SetActive(false);
        }
    }
}