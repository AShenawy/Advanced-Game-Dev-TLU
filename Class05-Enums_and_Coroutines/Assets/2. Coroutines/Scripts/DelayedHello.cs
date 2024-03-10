using System.Collections;
using UnityEngine;

public class DelayedHello : MonoBehaviour
{
    public float waitTime = 1.5f;

    bool isCoroutineRunning;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Can be called directly
            StartCoroutine(DelayedGreetingCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // Or called by string name
            StartCoroutine("DelayedGreeting");

            // C# nameof keyword helps with string errors
            StartCoroutine(nameof(DelayedGreetingCoroutine));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Trying to stop coroutine");
            StopCoroutine(nameof(DelayedGreetingCoroutine));
        }
    }

    void NormalGreetingFunction()
    {
        print("Normal Hello! - at: " + Time.time.ToString("0.00"));
    }


    // Coroutines must always return IEnumerator and contain at least one yield expression
    IEnumerator DelayedGreetingCoroutine()
    {
        // We can use a boolean to ensure coroutine runs only once
        if (isCoroutineRunning)
        {
            print("coroutine already running");
            yield break;
        }

        isCoroutineRunning = true;

        print("Gonna say hello! - at: " + Time.time.ToString("0.00"));

        // Stop execution using a yield and WaitForSeconds
        yield return new WaitForSeconds(waitTime);

        // Continue execution after waitTime has elapsed
        print("Delayed Hello! - at: " + Time.time.ToString("0.00"));

        isCoroutineRunning = false;
    }
}
