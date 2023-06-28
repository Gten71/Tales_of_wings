using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItems : MonoBehaviour
{
    public static UseItems instance;
    public CharacterController player; // Reference to the player script

    private void Start()
    {
        instance = this;
        player = CharacterController.Instance;
    }

    public void UseHealPosion(Item item)
    {
        if (item.isHealing)
        {
            player.Heal(item.PowerHealing); // Increase player's health
        }
    }
}