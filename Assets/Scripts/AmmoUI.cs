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
        // �������� ������ �� ��������� DataManager
        dataManager = FindObjectOfType<DataManager>();

        // ������ �������� ������
        int savedAmmo = dataManager.Ammo;
        characterController.SetCurrentAmmo(savedAmmo);
    }

    private void Update()
    {
        int currentAmmo = characterController.GetCurrentAmmo();

        // ��������� �������� ���������� �������� � ����������� ��������
        ammoText.text = "Ammo: " + currentAmmo.ToString();

        // ������ ���������� ������ ��� ��������� ���������� ��������
        dataManager.Ammo = currentAmmo;
    }
}