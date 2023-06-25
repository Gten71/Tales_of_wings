using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public Text ammoText;
    public CharacterController characterController;

    private void Update()
    {
        // ��������� �������� ���������� �������� � ����������� ��������
        ammoText.text = "Ammo: " + characterController.GetCurrentAmmo().ToString();
    }
}

