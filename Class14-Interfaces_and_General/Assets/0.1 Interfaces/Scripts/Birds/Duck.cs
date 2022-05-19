using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : Bird, IFlyable
{
    private List<GameObject> destinations;

    private bool isAtFinalDestination = false;

    public List<GameObject> Destinations { get => destinations; set => destinations = value; }

    public event Action<GameObject> OnArrivedDestination;

    public void FlyTo(List<GameObject> destinations)
    {
        if (destinations.Count > 0)
        {
            print("Duck is flying to " + destinations[0].name);

            // flap wings..
            // jump...

            OnArrivedDestination?.Invoke(destinations[0]);
        }
        else
        {
            print("There's no destination");
        }
    }

    public bool HasReachedFinalDestination()
    {
        return isAtFinalDestination;
    }
}