using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeInterval = 0.5f;

    private Material mat;

    void Start()
    {
        // Get the object's material from its mesh
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Normal function call
            //FadeAlpha();

            // Coroutines are called via StartCoroutine()
            StartCoroutine(FadeAlphaCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAlpha();
        }
    }

    // Regular function - Fading happens instantly
    private void FadeAlpha()
    {
        // Keep repeating the loop as long as there's some opacity in the material color
        while (mat.color.a >= 0.01f)
        {
            // Get a new alpha/transparency that's 10% less than before
            float newAlpha = mat.color.a - 0.1f;

            Color matColor = mat.color;

            // Apply new alpha (R,G, and B colors remain the same as original material)
            mat.color = new Color(matColor.r, matColor.g, matColor.b, newAlpha);
        }
    }

    // Coroutine - We can put stops to make execution gradual
    // Coroutines must return IEnumerator, and contain a "yield" in their implementation
    private IEnumerator FadeAlphaCoroutine()
    {
        // Keep repeating the loop as long as there's some opacity in the material color
        while (mat.color.a >= 0.01f)
        {
            // Get a new alpha/transparency that's 10% less than before
            float newAlpha = mat.color.a - 0.1f;

            Color matColor = mat.color;

            // Apply new alpha (R,G, and B colors remain the same as original material)
            mat.color = new Color(matColor.r, matColor.g, matColor.b, newAlpha);

            // Wait a time interval to pass before repeating the while loop
            yield return new WaitForSeconds(fadeInterval);
        }
    }

    void ResetAlpha()
    {
        mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1f);
    }
}
