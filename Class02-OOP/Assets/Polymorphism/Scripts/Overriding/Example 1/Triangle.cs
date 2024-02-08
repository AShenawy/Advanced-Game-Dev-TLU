using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : Shape
{
    public float baseLength;
    public float height;


    // If we don't override the method, then only the paren't part will execute
    // as, obviously, the child has no extra implementation of that method
    // i.e. the Triangle now has no area calculated
}
