using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Item SlotItem;
    public GameObject objItem;
    Image icon;
    Button btn;
    TextMeshProUGUI current;

    private void Start()
    {
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SlotClicked);
        current = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    //public void PutInSlot(Item item, GameObject obj)
    //{
    //    icon.sprite = item.icon;
    //    SlotItem = item;
    //    objItem = obj;
    //    icon.enabled = true;

    //    if (item.CurrI == 0 || item.CurrI == 1)
    //    {
    //        current.enabled = false;
    //    }
    //    else
    //    {
    //        current.enabled = true;
    //        current.text = item.CurrI.ToString();
    //    }
    //}
    public void PutInSlot(Item item, GameObject obj)
    {
        icon.sprite = item.icon;
        SlotItem = item;
        objItem = obj;
        icon.enabled = true;

        if (item.CurrI == 0 || item.CurrI == 1)
        {
            current.enabled = false;
        }
        else
        {
            current.enabled = true;
            current.text = item.CurrI.ToString();
        }
    }


    void SlotClicked()
    {
        if (SlotItem != null)
        {
            ItemInfo.Instance.Open(SlotItem, objItem, this);
        }
        else
        {
            ItemInfo.Instance.Close();
        }
    }

    public void ClearSlot()
    {
        SlotItem.CurrI -= 0.5f;

        if (SlotItem.CurrI <= 0)
        {
            SlotItem.CurrI = 0;
            SlotItem = null;
            objItem = null;
            icon.sprite = null;
            icon.enabled = false;
            if (current != null)
                current.enabled = false;
        }
        else
        {
            current.text = SlotItem.CurrI.ToString();
        }
    }



}
