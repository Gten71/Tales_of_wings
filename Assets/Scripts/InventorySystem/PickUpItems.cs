using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public Item item;
    private GameObject itemObj;
    private void Start()
    {
        itemObj = gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Inventory.Instance.PutInEmpteySlot(item, itemObj);
        }
    }
}

