using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public Transform slotParent;
    private InventoruSlot[] inventoruSlots;
    private DataManager dataManager;

    private void Start()
    {
        dataManager = FindObjectOfType<DataManager>();

        Instance = this;
        inventoruSlots = slotParent.GetComponentsInChildren<InventoruSlot>();

        // Загрузка данных инвентаря при старте
        if (dataManager != null)
        {
            for (int i = 0; i < inventoruSlots.Length; i++)
            {
                InventoruSlot slot = inventoruSlots[i];
                Item savedItem = dataManager.GetSavedItem(i);
                if (savedItem != null)
                {
                    GameObject savedObj = dataManager.GetSavedObject(i);
                    slot.PutInSlot(savedItem, savedObj);
                }
            }
        }
    }

    public void PutInEmptySlot(Item item, GameObject obj)
    {
        for (int i = 0; i < inventoruSlots.Length; i++)
        {
            InventoruSlot slot = inventoruSlots[i];
            if (slot.SlotItem != null && slot.SlotItem == item && slot.SlotItem.CurrI < slot.SlotItem.CurrMax)
            {
                slot.SlotItem.CurrI += item.CurrP;
                if (slot.SlotItem.CurrI > slot.SlotItem.CurrMax)
                    slot.SlotItem.CurrI = slot.SlotItem.CurrMax;
                slot.PutInSlot(slot.SlotItem, obj);

                // Сохранение данных инвентаря после изменения
                if (dataManager != null)
                {
                    dataManager.SaveItem(i, slot.SlotItem);
                    dataManager.SaveObject(i, obj);
                }
                return;
            }

            if (slot.SlotItem == null)
            {
                item.CurrI = item.CurrP;
                slot.PutInSlot(item, obj);

                // Сохранение данных инвентаря после изменения
                if (dataManager != null)
                {
                    dataManager.SaveItem(i, item);
                    dataManager.SaveObject(i, obj);
                }
                return;
            }
        }
    }

    // Остальные методы вашего кода...

    public void Open()
    {
        gameObject.transform.localScale = Vector3.one;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}