using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : PickUp
{
    public override void ConsumePickup()
    {
        print("it's a powerup!");
        player.energy += energyValue;
    }
}
