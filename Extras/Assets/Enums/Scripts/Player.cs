using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int energy = 10;

    public void TakeItem(PickUp item)
    {
        print("Item taken: " + item.name);
        
    }
}
