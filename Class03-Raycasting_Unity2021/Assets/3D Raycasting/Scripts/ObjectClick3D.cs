using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick3D : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("Clicked on " + name);
    }

    private void OnMouseEnter()
    {
        print("Mouse entered collider of " + name);
    }

    private void OnMouseExit()
    {
        print("Mouse exited collider of " + name);
    }

}
