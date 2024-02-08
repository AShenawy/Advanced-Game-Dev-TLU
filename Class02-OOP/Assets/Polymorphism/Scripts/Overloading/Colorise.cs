using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorise : MonoBehaviour
{
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }


    // Called via button click
    // Assign a random colour to the sprite
    public void ChangeColor()
    {
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        renderer.color = newColor;
    }


    // We Overload the function by changing either the type of number of parameters
    public void ChangeColor(Color newColor)
    {
        renderer.color = newColor;
    }
}
