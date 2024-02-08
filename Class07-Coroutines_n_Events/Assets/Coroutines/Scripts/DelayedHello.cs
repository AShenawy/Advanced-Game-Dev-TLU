using System.Collections;
using UnityEngine;

public class DelayedHello : MonoBehaviour
{
    public float waitTime = 1.5f;

    bool isCoroutineRunning;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Can be called directly
            StartCoroutine(SayHelloAfter());
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // Or called by string name
            StartCoroutine("SayHelloAfter");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Trying to stop Hello coroutine");
            StopCoroutine("SayHelloAfter");

            // Set the boolean to false in case of early stop,
            // where the coroutine won't finish or be able to set the bool
            isCoroutineRunning = false;
        }
    }

  
    // Coroutines must always return IEnumerator and contain at least one yield expression
    IEnumerator SayHelloAfter()
    {
        if (isCoroutineRunning)
        {
            // Exit the coroutine and don't continue if it's already running
            print("Coroutine is already running");
            yield break;
        }

        isCoroutineRunning = true;

        print("Gonna say hello! - at: " + Time.time.ToString("0.00"));

        // Stop execution using a yield and WaitForSeconds
        yield return new WaitForSeconds(waitTime);

        // Continue execution after waitTime has elapsed
        print("Hello! - at: " + Time.time.ToString("0.00"));

        isCoroutineRunning = false;
    }
}
