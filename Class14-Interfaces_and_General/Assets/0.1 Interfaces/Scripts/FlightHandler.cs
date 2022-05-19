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
        foreach (GameObject obj in flyingObjects)
        {
            IFlyable flyable = obj.GetComponent<IFlyable>();

            //if we found a script that inherits from IFlyable, we can use it
            if (flyable != null)
            {
                flyable.FlyTo(destinationObjects);
            }
        }
    }
}
