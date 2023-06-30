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

        // Пример загрузки данных
        int savedAmmo = dataManager.Ammo;
        characterController.SetCurrentAmmo(savedAmmo);
    }

    private void Update()
    {
        int currentAmmo = characterController.GetCurrentAmmo();

        // Обновляем значение текстового элемента с количеством патронов
        ammoText.text = "Ammo: " + currentAmmo.ToString();

        // Пример сохранения данных при изменении количества патронов
        dataManager.Ammo = currentAmmo;
    }
}