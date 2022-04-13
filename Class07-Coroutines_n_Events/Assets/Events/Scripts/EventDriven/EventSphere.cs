using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSphere : MonoBehaviour
{
    public Material matInactive;
    public Material matActive;
    MeshRenderer mesh;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();


    }

    private void OnEnable()
    {
        EventCube.OnActivate += ActivateSphere;
        EventCube.OnActivate += Activate;
        EventCube.OnDeactivate += DeactivateSphere;
    }


    public void Activate(int value)
    {

    }

    public void ActivateSphere(int v)
    {
        print("Activate Event Invoked!");
        mesh.material = matActive;
    }

    public void DeactivateSphere()
    {
        print("Deactivate Event Invoked!");
        mesh.material = matInactive;
    }

    private void OnDisable()
    {
        EventCube.OnActivate -= ActivateSphere;
        EventCube.OnDeactivate -= DeactivateSphere;
    }
}
