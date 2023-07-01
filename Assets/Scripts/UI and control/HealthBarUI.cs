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

        // Получаем ссылку на экземпляр DataManager
        dataManager = FindObjectOfType<DataManager>();

        // Загрузка сохраненного здоровья при старте
        if (dataManager != null)
        {
            characterController.currentHealth = dataManager.HP;
        }
    }

    private void OnDestroy()
    {
        // Сохранение текущего здоровья при уничтожении объекта
        if (dataManager != null)
        {
            dataManager.HP = characterController.currentHealth;
        }
    }

    private void Update()
    {
        // Обновление значения полоски здоровья равным текущему здоровью персонажа
        healthSlider.value = characterController.currentHealth;
    }

}

