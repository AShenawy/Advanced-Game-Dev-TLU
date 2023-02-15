using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    public Slider red;
    public Slider green;
    public Slider blue;

    public Colorise coloriser;  // Reference to the script on the Square game object

    private Image colourPreview;
    private Color newColor;

    
    void Start()
    {
        colourPreview = GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        // Read & store the values from colour sliders
        float redValue = red.value;
        float greenValue = green.value;
        float blueValue = blue.value;

        // Save the color information
        newColor = new Color(redValue, greenValue, blueValue);

        // Update the UI colour preview image
        colourPreview.color = newColor;
    }


    // Called via button click
    public void ApplyColour()
    {
        // C# automatically calls the correct function overload based
        // on the amount and types of given parameters (or no parameters at all)
        coloriser.ChangeColor(newColor);
    }
}
