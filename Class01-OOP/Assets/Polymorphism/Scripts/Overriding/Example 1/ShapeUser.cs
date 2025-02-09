using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeUser : MonoBehaviour
{
    // Through Inheritance, this variable accepts any script that is Shape or
    // inherits from Shape: Triangle, Square, Circle, Hexagon
    public Shape shape;

    // Start is called before the first frame update
    void Start()
    {
        shape.GetArea();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
