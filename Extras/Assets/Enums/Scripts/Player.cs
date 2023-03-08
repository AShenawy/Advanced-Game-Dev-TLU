using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int energy = 10;

    public void TakeItem(PickUp item)
    {
        print("Item taken: " + item.name);

        switch (item.type)
        {
            case PickupType.Food:
                print("it's food!");
                energy += item.energyValue;
                break;

            case PickupType.Powerup:
                print("it's a powerup!");
                energy += item.energyValue;
                break;

            case PickupType.Equipment:
                print("it's equipment!");
                energy -= item.energyValue;
                break;
        }
    }
}

public enum PickupType { Food, Powerup, Equipment }