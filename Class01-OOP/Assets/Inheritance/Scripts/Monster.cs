using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // In the Base/Parent class we add all the common data and functionality

    //[HideInInspector]
    public int healthPoints;
    public int attackPoints;
    public int defencePoints;


    public void Attack()
    {
        // Attack something
    }

    public void TakeDamage(int amount)
    {
        // Take damage from attacks
        healthPoints -= amount;
    }
}
