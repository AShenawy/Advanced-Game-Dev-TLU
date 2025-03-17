using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Material matInactive;
    public Material matActive;
    MeshRenderer mesh;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
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
}
