using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventSphere : MonoBehaviour
{
    public Material matInactive;
    public Material matActive;
    MeshRenderer mesh;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();

        // Subscribe to the events with functions to call once an event is raised/invoked
        EventCube.OnActivate += ActivateSphere;
        EventCube.OnDeactivate += DeactivateSphere;
    }

    public void ActivateSphere()
    {
        print("Activating " + name);
        mesh.material = matActive;
    }

    public void DeactivateSphere()
    {
        print("Deactivating " + name);
        mesh.material = matInactive;
    }

    void OnDestroy()
    {
        // Unsubscribe from the events in case thig game object is destroyed in the scene
        EventCube.OnActivate -= ActivateSphere;
        EventCube.OnDeactivate -= DeactivateSphere;
    }
}
