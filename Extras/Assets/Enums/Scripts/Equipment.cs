using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : PickUp
{
    public override void ConsumePickup()
    {
        print("it's equipment!");
        player.energy -= energyValue;
    }
}
