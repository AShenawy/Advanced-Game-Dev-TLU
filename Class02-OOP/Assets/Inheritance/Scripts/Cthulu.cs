using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cthulu : Monster
{
    private void Start()
    {
        // All (public) variables and functions are accessible by the Child class
        hp = 20;
        attackPoints = 50;
        TakeDamage(4);
    }


    // We only need to add what's unique to the Derived class
    // All the common stuff remain in the Base class
    public void Crawl()
    {
        // Move
    }
}
