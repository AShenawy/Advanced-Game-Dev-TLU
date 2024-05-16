using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : Bird, IFlyable
{
    // Declaring a property with empty get/set. C# will generate a "hidden" variable
    // in the background to use for it, so we don't have to make one ourselves
    public List<GameObject> Destinations { get; set; }

    public void FlyTo(List<GameObject> destinations)
    {
        Destinations = destinations;
        print("Duck is flying to " + destinations[0].name);

        /*
         * Duck logic:
         * Run
         * Flap wings
         * Jump and fly away
         */ 
    }

    public bool HasReachedFinalDestination()
    {
        return Destinations.Count == 0;
    }

}