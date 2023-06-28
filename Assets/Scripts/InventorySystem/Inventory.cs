using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public Transform slotParent;
    private ItemInfo inf;
    private InventoruSlot[] inventoruSlots = new InventoruSlot[12];
    private void Start()
    {
        Instance = this;
        for (int i = 0; i < inventoruSlots.Length; i++)
        {
            inventoruSlots[i] = slotParent.GetChild(i).GetComponent<InventoruSlot>();
        }
    }

    public void PutInEmpteySlot(Item item, GameObject obj)
    {
        for (int i = 0; i < inventoruSlots.Length; i++)
        {

            if(inventoruSlots[i].SlotItem == item)
            {
                if (item.CurrMax != item.CurrI)
                {
                    item.CurrI += item.CurrP;
                    return;
                }
                return;
            }

            if(inventoruSlots[i].SlotItem == null)
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