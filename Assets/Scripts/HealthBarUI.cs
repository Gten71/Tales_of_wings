using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider; // Ссылка на компонент Slider, отображающий полоску здоровья
    public CharacterController characterController; // Ссылка на скрипт CharacterController персонажа 
    private DataManager dataManager;

    private void Start()
    {
        // Установите максимальное значение полоски здоровья равным максимальному здоровью персонажа
        healthSlider.maxValue = characterController.maxHealth;

        // Найти или создать экземпляр DataManager
        dataManager = FindObjectOfType<DataManager>();

        // Загрузить сохраненное здоровье, если оно есть
        if (dataManager != null)
        {
            characterController.currentHealth = dataManager.HP;
        }
    }

    private void OnDestroy()
    {
        // Сохранить текущее здоровье при уничтожении объекта
        if (dataManager != null)
        {
            dataManager.HP = characterController.currentHealth;
        }
    }

    private void Update()
    {
        // Обновите значение полоски здоровья равным текущему здоровью персонажа
        healthSlider.value = characterController.currentHealth;
    }
}

