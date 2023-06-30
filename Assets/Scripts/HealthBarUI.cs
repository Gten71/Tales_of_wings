using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider; // ������ �� ��������� Slider, ������������ ������� ��������
    public CharacterController characterController; // ������ �� ������ CharacterController ��������� 
    private DataManager dataManager;

    private void Start()
    {
        // ���������� ������������ �������� ������� �������� ������ ������������� �������� ���������
        healthSlider.maxValue = characterController.maxHealth;

        // ����� ��� ������� ��������� DataManager
        dataManager = FindObjectOfType<DataManager>();

        // ��������� ����������� ��������, ���� ��� ����
        if (dataManager != null)
        {
            characterController.currentHealth = dataManager.HP;
        }
    }

    private void OnDestroy()
    {
        // ��������� ������� �������� ��� ����������� �������
        if (dataManager != null)
        {
            dataManager.HP = characterController.currentHealth;
        }
    }

    private void Update()
    {
        // �������� �������� ������� �������� ������ �������� �������� ���������
        healthSlider.value = characterController.currentHealth;
    }
}

