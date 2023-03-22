using System.Collections;
using UnityEngine;

public class DelayedHello : MonoBehaviour
{
    public float waitTime = 1.5f;

    IEnumerator coroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coroutine == null)
            {
                coroutine = SayHelloAfter();
                // Can be called directly
                StartCoroutine(SayHelloAfter());
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // Or called by string name
            StartCoroutine("SayHelloAfter");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StopCoroutine("SayHelloAfter");
        }
    }

    bool isCorotStarted;
    // Coroutines must always return IEnumerator and contain at least one yield expression
    IEnumerator SayHelloAfter()
    {
        if (isCorotStarted)
        {
            yield break;
        }

        isCorotStarted = true;

        print("Gonna say hello! - " + Time.time.ToString("0.00"));

        // Stop execution using a yield and WaitForSeconds
        yield return new WaitForSeconds(waitTime);

        // Continue execution after waitTime has elapsed
        print("Hello! - " + Time.time.ToString("0.00"));

        isCorotStarted = false;
        coroutine = null;
    }
}
