using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int energy = 50;
    public const string playerTag = "Player";


    public void TakeItem(PickUp item)
    {
        // Take item and increase/decrease energy based on item type
        // Food and Power ups increase energy
        // Equipment decrease energy

        switch (item.type)
        {
            // Checking for default is even more important when we have a NONE in our enum
            default:
                // No choice made. Do nothing
                Debug.LogWarning("undefined type");
                break;

            case ItemType.Food:
            case ItemType.Powerup:
                print("gained energy: " + item.energyValue);
                energy += item.energyValue;
                break;

            case ItemType.Equip:
                print("lost energy: " + item.energyValue);
                energy -= item.energyValue;
                break;

        }

    }
}