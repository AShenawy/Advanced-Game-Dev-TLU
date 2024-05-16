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
            print("Trying to fly: " + obj.name);

            // Get a script component that implements the IFlyable interface
            IFlyable flyingObject = obj.GetComponent<IFlyable>();

            if (flyingObject != null)
            {
                flyingObject.FlyTo(destinationObjects);
            }
            else
            {
                print("Can't fly :(");
            }
        }
    }
}