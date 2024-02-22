using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick2D : MonoBehaviour
{
    // These will only work if the game object has a collider on it

    private void OnMouseDown()
    {
        print("Clicked on " + name);
    }

    private void OnMouseEnter()
    {
        print("Entered");
    }

    private void OnMouseExit()
    {
        print("Exited");
    }
}
