using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCube : MonoBehaviour
{
    public static event UnityAction<int> OnActivate;
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
        OnActivate?.Invoke(2);
        
    }

    void Deactivate()
    {
        print("Invoking Deactivate Event!");
        OnDeactivate();
    }
}
