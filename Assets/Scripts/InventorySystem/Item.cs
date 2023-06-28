using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Базовые характеристики")]
    public string Name = "";
    public string Description = "Описание предмета";
    public Sprite icon = null;
    public int CurrP;
    public int CurrI=0;
    public int CurrMax;
    public bool isHealing;
    public int PowerHealing;
}
