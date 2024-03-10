using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{ 
    Food = 10,      // We can assign a different value (here is 10) than the default C# indexing
    Equip = 20,
    Powerup = 30,
    
    NONE            // In some cases it's useful to have a "blank" or no choice option
};


public class PickUp : MonoBehaviour
{
    public int energyValue;
    public Player player;
    public ItemType type = ItemType.NONE;

    void OnMouseUpAsButton()
    {
        player.TakeItem(this);
        Destroy(gameObject);
    }

}