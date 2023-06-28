using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoruSlot : MonoBehaviour
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

    public void PutInSlot(Item item, GameObject obj)
    {
        icon.sprite = item.icon;
        SlotItem = item;
        objItem = obj;
        icon.enabled = true;

        if (item.stackSize <= 1)
        {
            current.enabled = false;
        }
        else
        {
            current.enabled = true;
            current.text = item.stackSize.ToString();
        }
    }

    public void AddToSlot(Item item, GameObject obj)
    {
        if (SlotItem != null && SlotItem.Name == item.Name)
        {
            SlotItem.stackSize += item.CurrP; // �������� �������� stackSize �� �������� CurrP
            current.text = SlotItem.stackSize.ToString(); // ��������� ����������� ���������� ��������� � �����
        }
        else
        {
            PutInSlot(item, obj);
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
        if (SlotItem != null)
        {
            SlotItem.stackSize--;

            if (SlotItem.stackSize <= 0)
            {
                SlotItem = null;
                objItem = null;
                icon.sprite = null;
                icon.enabled = false;
                current = null;
                current.enabled = false;
            }
            else
            {
                current.text = SlotItem.stackSize.ToString(); // ��������� ����������� ���������� ��������� � �����
            }
        }
    }
}