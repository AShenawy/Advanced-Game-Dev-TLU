using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
