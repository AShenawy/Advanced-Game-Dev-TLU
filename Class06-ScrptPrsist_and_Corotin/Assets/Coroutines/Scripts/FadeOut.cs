using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Normal function call
            //FadeAlpha();

            // Coroutines are called via StartCoroutine()
            StartCoroutine(FadeAlphaCoroutine());
        }
    }

    // Regular function - Fading happens instantly
    private void FadeAlpha()
    {
        // Get the object's material from its mesh
        Material material = GetComponent<MeshRenderer>().material;

        // Keep repeating the loop as long as there's some transparency in the material color
        while (material.color.a >= 0.01f)
        {
            // Get a new alpha/transparency that's 10% less than before
            float newAlpha = material.color.a - 0.1f;

            Color color = material.color;

            // Apply new alpha (R,G, and B colors remain the same)
            material.color = new Color(color.r, color.g, color.b, newAlpha);
        }
    }

    // Coroutine - We can put stops to make execution gradual
    // Coroutines must return IEnumerator, and contain a "yield" in their implementation
    private IEnumerator FadeAlphaCoroutine()
    {
        // Get the object's material from its mesh
        Material material = GetComponent<MeshRenderer>().material;

        // Keep repeating the loop as long as there's some transparency in the material color
        while (material.color.a >= 0.01f)
        {
            // Get a new alpha/transparency that's 10% less than before
            float newAlpha = material.color.a - 0.1f;

            Color matColor = material.color;

            // Apply new alpha (R,G, and B colors remain the same)
            material.color = new Color(matColor.r, matColor.g, matColor.b, newAlpha);

            // Wait 0.5 seconds before repeating the loop
            yield return new WaitForSeconds(0.5f);
        }
    }
}
