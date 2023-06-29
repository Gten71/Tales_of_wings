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
        if (characterController.HasAmmo() && characterController.target != null && characterController.shootingArea.OverlapPoint(characterController.target.position))
        {
            characterController.Shoot();
            characterController.LookAtTarget();
        }
    }

}

