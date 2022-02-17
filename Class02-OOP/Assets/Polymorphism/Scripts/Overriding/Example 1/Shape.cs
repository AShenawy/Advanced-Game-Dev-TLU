using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public float area;  // Area is a common characteristic for all shapes

    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        //print("My shape is: " + gameObject.name);
        GetArea();
    }

    public void RandomiseColor()
    {
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        renderer.color = newColor;
    }


    // A virtual method can also be empty (just curly braces). This way we tell the program that any class
    // derived from 'Shape' class will have this method, but each child class executes it differently
    public virtual void GetArea()
    {
        print("The area of " + name + " is " + area);
    }
}
