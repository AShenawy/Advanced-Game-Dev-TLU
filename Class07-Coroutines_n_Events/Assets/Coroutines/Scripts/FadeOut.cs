using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeInterval = 0.5f;

    private Material material;

    Coroutine runningCoroutine = null;
    

    void Start()
    {
        // Get the object's material from its mesh
        material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Normal function call
            //FadeAlpha();

            // Direct corouting call (cannot be selectively stopped)
            //StartCoroutine(FadeAlphaCoroutine());

            // Calling coroutine by its string name
            //StartCoroutine("FadeAlphaCoroutine");
            //StartCoroutine(nameof(FadeAlphaCoroutine));

            // Calling coroutine via a reference value and checking if it's not already running
            if (runningCoroutine == null)
            {
                runningCoroutine = StartCoroutine(FadeAlphaCoroutine());
            }
            else
            {
                print("coroutine is already running");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (runningCoroutine != null)
            {
                // Stopping ALL coroutines running in this script, no matter how they were called
                //StopAllCoroutines();

                // Stopping a coroutine by string name
                //StopCoroutine("FadeAlphaCoroutine");
                //StopCoroutine(nameof(FadeAlphaCoroutine));

                // Stopping a coroutine by a reference
                StopCoroutine(runningCoroutine);
                ResetAlpha();

                // Set it to null so it can be called again above
                runningCoroutine = null;
            }
        }
    }

    // Regular function - Fading happens instantly
    private void FadeAlpha()
    {
        // Keep repeating the loop as long as there's some opacity in the material color
        while (material.color.a >= 0.01f)
        {
            // Get a new alpha/transparency that's 10% less than before
            float newAlpha = material.color.a - 0.1f;

            Color matColor = material.color;

            // Apply new alpha (R,G, and B colors remain the same as original material)
            material.color = new Color(matColor.r, matColor.g, matColor.b, newAlpha);
        }
    }


    // Coroutine - We can put stops to make execution gradual
    // Coroutines must return IEnumerator, and contain a "yield" in their implementation
    private IEnumerator FadeAlphaCoroutine()
    {
        // Keep repeating the loop as long as there's some opacity in the material color
        while (material.color.a >= 0.01f)
        {
            // Get a new alpha/transparency that's 10% less than before
            float newAlpha = material.color.a - 0.1f;

            Color matColor = material.color;

            // Apply new alpha (R,G, and B colors remain the same as original material)
            material.color = new Color(matColor.r, matColor.g, matColor.b, newAlpha);

            // Wait a time interval to pass before repeating the while loop
            yield return new WaitForSeconds(fadeInterval);
        }
    }

    void ResetAlpha()
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b, 1f);
    }
}
