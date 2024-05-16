using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiPlane : Plane, IFlyable
{
    // We create this variable to support the _Destinations_ property (called Backing Field),
    // which gives us more control over the property. See declaration of the property below
    private List<GameObject> destinations;


    // With a backing field (the _destinations_ variable), we can control how _get_ and _set_ work
    public List<GameObject> Destinations 
    {
        get => destinations;
        set => destinations = value;
    }

    public void FlyTo(List<GameObject> destinations)
    {
        // We use _this_ to clarify which variable we mean, when both class and function variables have the same name
        // _this.destinations_ refers to the variable defined in the class above. While _destinations_ refers to the function's parameter
        this.destinations = destinations;

        print("BiPlane is flying to " + destinations[0].name);
        
        /*
         * Plane logic:
         * Go to the runway 
         * Start engines
         * Speed up and fly away
         */
    }

    public bool HasReachedFinalDestination()
    {
        // return true if all no more destinations left
        return destinations.Count == 0;
    }
}