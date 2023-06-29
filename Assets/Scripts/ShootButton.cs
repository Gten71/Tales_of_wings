using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour
{
    public Button shootButton;
    public CharacterController characterController;
    private void Start()
    {
        // Подписываемся на событие нажатия кнопки
        shootButton.onClick.AddListener(OnShootButtonClick);
    }


          



        private void OnShootButtonClick()
    {
        if (characterController.HasAmmo())
        {
            characterController.Shoot();
         //   characterController.LookAtTarget();
        }
        // Вызываем стрельбу у персонажа
        
    }
}

