using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCube : MonoBehaviour
{
    // Declare events
    public static event UnityAction OnActivate;
    public static event UnityAction OnDeactivate;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Activate();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Deactivate();
        }
    }

    void Activate()
    {
        print("Invoking Activate Event!");

        // Invoke the event after checking if it's not null (has subscribers)
        OnActivate?.Invoke();
    }

    void Deactivate()
    {
        print("Invoking Deactivate Event!");

        // Invoke the event after checking if it's not null (has subscribers)
        OnDeactivate?.Invoke();
    }
}
