using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlyable
{
    // Property declaration
    List<GameObject> Destinations { get; set; }

    // Functions have no body (no content between braces) in interfaces
    void FlyTo(List<GameObject> destinations);

    bool HasReachedFinalDestination();
}
