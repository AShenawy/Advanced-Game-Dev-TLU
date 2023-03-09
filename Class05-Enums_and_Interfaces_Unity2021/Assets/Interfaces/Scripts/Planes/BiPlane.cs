using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiPlane : Plane, IFlyable
{
    private List<GameObject> destinations;

    public List<GameObject> Destinations 
    {
        get => destinations;
        set => destinations = value;
    }

    public void FlyTo(List<GameObject> destinations)
    {
        // We use _this_ to clarify which variable we mean, when both class and function variables have the same name
        this.destinations = destinations;

        print("BiPlane is flying to " + destinations[0].name);
        
        // Biplane logic goes here to make it fly
        // Go to the runway 
        // Start engines
        // Speed up
    }

    public bool HasReachedFinalDestination()
    {
        // return true if all no more destinations left
        return destinations.Count == 0;
    }
}