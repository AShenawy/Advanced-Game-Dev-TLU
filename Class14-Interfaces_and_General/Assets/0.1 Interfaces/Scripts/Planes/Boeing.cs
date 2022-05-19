using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boeing : Plane, IFlyable
{
    public List<GameObject> Destinations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public event Action<GameObject> OnArrivedDestination;

    public void FlyTo(List<GameObject> destinations)
    {
        if (destinations.Count > 0)
        {
            print("Boeing is flying to " + destinations[0].name);

            // Go to runway..
            // accelerate..

            OnArrivedDestination?.Invoke(destinations[0]);
        }
        else
        {
            print("There's no destination");
        }
    }

    public bool HasReachedFinalDestination()
    {
        throw new NotImplementedException();
    }
}
