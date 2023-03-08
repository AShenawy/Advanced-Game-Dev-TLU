using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int energyValue;
    public PickupType type;
    public Player player;

    void OnMouseUpAsButton()
    {
        player.TakeItem(this);
        Destroy(gameObject);
    }

    public virtual void ConsumePickup()
    {
        // Implement in child classes
    }
}