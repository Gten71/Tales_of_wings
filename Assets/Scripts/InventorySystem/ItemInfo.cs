using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    public static ItemInfo Instance;
    private Image BackGround;
    private Image Icon;
    private TextMeshProUGUI Title;
    private TextMeshProUGUI Description;
    private Button Use;
    private Button Delete;
    private Button Drop;
    private Item itemInf;
    private GameObject itemObj;
    private InventorySlot cerSlot;

    private void Start()
    {
        Instance = this;
        BackGround = GetComponent<Image>();
        Title = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Description = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        Icon = transform.GetChild(2).GetComponent<Image>();
        Use = transform.GetChild(4).GetComponent<Button>();
        Delete = transform.GetChild(5).GetComponent<Button>();
        Drop = transform.GetChild(6).GetComponent<Button>();

        Use.onClick.AddListener(UseItem);
        Delete.onClick.AddListener(DeleteItem);
        Drop.onClick.AddListener(DropItem);
    }

    public void ChangeInfo(Item item)
    {
        Title.text = item.Name;
        Description.text = item.Description;
        Icon.sprite = item.icon;
    }

    public void UseItem()
    {
        UseItems.instance.UseHealPosion(itemInf);

        // Проверка, является ли предмет предметом для повышения боеприпасов
        if (itemInf.isAmmoIncrease )
        {
            CharacterController.Instance.IncreaseAmmo(itemInf.AmmoIncrease);
        }

        cerSlot.ClearSlot();
        Close();
    }


    public void DropItem()
    {
        Vector3 droppos = new Vector3(CharacterController.Instance.transform.position.x + 2f, CharacterController.Instance.transform.position.y, CharacterController.Instance.transform.position.z);
        itemObj.SetActive(true);
        itemObj.transform.position = droppos;
        cerSlot.ClearSlot();
        Close();
    }

    public void DeleteItem()
    {
        cerSlot.ClearSlot();
        Close();
    }

    public void Open(Item item, GameObject obj, InventorySlot currentSlot)
    {
        ChangeInfo(item);
        itemInf = item;
        itemObj = obj;
        cerSlot = currentSlot;
        gameObject.transform.localScale = Vector3.one;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}
