using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : Bird, IFlyable
{
    // Visual Studio automatically throws errors if we choose the auto-implementation option for interfaces
    public List<GameObject> Destinations 
    { 
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public void FlyTo(List<GameObject> destinations)
    {
        print("Duck  is flying to " + destinations[0].name);
        
        // Duck logic goes here to make it fly
        // Run
        // Flap wings
        // Jump
    }

    public bool HasReachedFinalDestination()
    {
        return true;    // Placeholder for the function's return value. Actual logic needs to be implemented
    }

}