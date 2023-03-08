using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : PickUp
{
    public override void ConsumePickup()
    {
        print("it's food!");
        player.energy += energyValue;
    }
}
