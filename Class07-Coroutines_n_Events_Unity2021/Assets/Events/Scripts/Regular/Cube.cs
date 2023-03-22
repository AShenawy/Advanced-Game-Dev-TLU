using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public List<Sphere> spheres;

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
        print("Activate Spheres!");
        foreach (Sphere sphere in spheres)
        {
            sphere.ActivateSphere();
        }
    }

    void Deactivate()
    {
        print("Dectivate Spheres!");
        foreach(Sphere sphere in spheres)
        {
            sphere.DeactivateSphere();
        }
    }
}
