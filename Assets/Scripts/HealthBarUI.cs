using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider; // Ссылка на компонент Slider, отображающий полоску здоровья
    public CharacterController characterController; // Ссылка на скрипт CharacterController персонажа

    private void Start()
    {
        // Установите максимальное значение полоски здоровья равным максимальному здоровью персонажа
        healthSlider.maxValue = characterController.maxHealth;
    }

    private void Update()
    {
        // Обновите значение полоски здоровья равным текущему здоровью персонажа
        healthSlider.value = characterController.currentHealth;
    }
}

