using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : Shape
{
    public float sideLength;


    public override void GetArea()
    {
        float sideSquared = sideLength * sideLength;
        area = 3f * Mathf.Sqrt(3f) * 0.5f * sideSquared;

        base.GetArea();
    }
}
