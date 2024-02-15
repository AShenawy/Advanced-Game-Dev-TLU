using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : Shape
{
    public float sideLength;


    // By overriding a parent's virtual method we implement something new in the child,
    // with the choice to still execute the original method, via the 'base' keyword
    public override void GetArea()
    {
        float sideSquared = sideLength * sideLength;
        area = 3f * Mathf.Sqrt(3f) * 0.5f * sideSquared;

        base.GetArea();
    }
}
