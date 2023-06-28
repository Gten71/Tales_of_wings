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
            InventoruSlot slot = inventoruSlots[i];
            if (slot.SlotItem != null && slot.SlotItem == item && slot.SlotItem.CurrI < slot.SlotItem.CurrMax)
            {
                slot.SlotItem.CurrI += item.CurrP;
                if (slot.SlotItem.CurrI > slot.SlotItem.CurrMax)
                    slot.SlotItem.CurrI = slot.SlotItem.CurrMax;
                slot.PutInSlot(slot.SlotItem, obj);
                return;
            }

            if (slot.SlotItem == null)
            {
                item.CurrI = item.CurrP;
                slot.PutInSlot(item, obj);
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
