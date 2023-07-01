using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public Text ammoText;
    public CharacterController characterController;

    private DataManager dataManager;

    private void Start()
    {
        // Получаем ссылку на экземпляр DataManager
        dataManager = FindObjectOfType<DataManager>();

        // Загрузка сохраненного количества патронов при старте
        if (dataManager != null)
        {
            int savedAmmo = dataManager.Ammo;
            characterController.SetCurrentAmmo(savedAmmo);
        }
    }

    private void Update()
    {
        int currentAmmo = characterController.GetCurrentAmmo();

        // Обновляем значение текстового элемента с количеством патронов
        ammoText.text = "Ammo: " + currentAmmo.ToString();

        // Сохраняем данные при изменении количества патронов
        if (dataManager != null)
        {
            dataManager.Ammo = currentAmmo;
        }
    }

}