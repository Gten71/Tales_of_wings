using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider; // ������ �� ��������� Slider, ������������ ������� ��������
    public CharacterController characterController; // ������ �� ������ CharacterController ���������

    private void Start()
    {
        // ���������� ������������ �������� ������� �������� ������ ������������� �������� ���������
        healthSlider.maxValue = characterController.maxHealth;
    }

    private void Update()
    {
        // �������� �������� ������� �������� ������ �������� �������� ���������
        healthSlider.value = characterController.currentHealth;
    }
}

