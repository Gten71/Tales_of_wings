using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public Transform slotParent;
    private InventoruSlot[] inventoruSlots;

    private void Start()
    {
        Instance = this;
        inventoruSlots = slotParent.GetComponentsInChildren<InventoruSlot>();
    }

    public void PutInEmptySlot(Item item, GameObject obj)
    {
        for (int i = 0; i < inventoruSlots.Length; i++)
        {
            if (inventoruSlots[i].SlotItem == item)
            {
                if (item.CurrMax > item.CurrI)
                {
                    item.CurrI++; // Увеличиваем количество предметов в стаке
                    inventoruSlots[i].AddToSlot(item, obj); // Добавляем предмет в слот и обновляем отображение
                }
                return;
            }

            if (inventoruSlots[i].SlotItem == null)
            {
                item.CurrI = 1;
                inventoruSlots[i].PutInSlot(item, obj);
                return;
            }
        }
    }




    public void Open()
    {
        gameObject.transform.localScale = Vector3.one;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}