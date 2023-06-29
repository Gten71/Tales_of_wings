using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("������� ��������������")]
    public string Name = "";
    public string Description = "�������� ��������";
    public Sprite icon = null;
    public int CurrP;
    public float CurrI;
    public int CurrMax;
    public bool isHealing;
    public int PowerHealing;
}
