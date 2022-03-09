using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : Shape
{
    public float sideLength;

    // Since we want to keep using Start in parent class, we "override" the Start method
    public override void Start()
    {
        print("Start from Child");
        base.Start();
    }

    // By overriding a parent's virtual method we implement something new in the child,
    // with the choice to still execute the original method, via the 'base' keyword
    public override void GetArea()
    {
        area = sideLength * sideLength;
        
        // the base method is called at the end, after the result is stored in 'area' variable
        // and 'print' in Shape class can show the correct value of the area
        base.GetArea();
    }
}
