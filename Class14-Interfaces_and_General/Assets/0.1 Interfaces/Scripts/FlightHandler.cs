using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightHandler : MonoBehaviour
{
    public List<GameObject> flyingObjects;
    public List<GameObject> destinationObjects;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            MakeAllFly();
        }
    }

    void MakeAllFly()
    {
        // Loop through every flying object in the list
        foreach (GameObject obj in flyingObjects)
        {
            print("Flying: " + obj.name);

            // Get a script component that has IFlyable 
            IFlyable flyingObject = obj.GetComponent<IFlyable>();

            // if we're able to get the component, call the IFlyable components on it
            if (flyingObject != null)
            {
                flyingObject.FlyTo(destinationObjects);

                bool flightEnded = flyingObject.HasReachedFinalDestination();
            }
        }
    }
}