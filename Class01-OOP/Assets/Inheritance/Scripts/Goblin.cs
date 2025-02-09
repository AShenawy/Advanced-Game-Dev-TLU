using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
    private void Start()
    {
        // All public variables and functions are accessible by the Child class
        healthPoints = 20;
        attackPoints = 50;
        TakeDamage(4);
    }

    // We only need to add what's unique to the Derived class
    // All the common stuff remain in the Base class
    public void Run()
    {
        // Move
    }
}
