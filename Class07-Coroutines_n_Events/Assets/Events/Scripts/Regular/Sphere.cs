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
        print("Activate method called!");
        mesh.material = matActive;
    }

    public void DeactivateSphere()
    {
        print("Deactivate method called!");
        mesh.material = matInactive;
    }
}
