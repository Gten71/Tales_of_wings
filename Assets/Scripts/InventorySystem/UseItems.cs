using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItems : MonoBehaviour
{
    public static UseItems instance;
    private void Start()
    {
        instance = this;
    }

    public void UseHealPosion(Item item)
    {
        if (item.isHealing)
        {
            Debug.Log("Отхилило-" + item.PowerHealing);
        }
    }
}
