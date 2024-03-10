using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiYield : MonoBehaviour
{
    public float waitTime1 = 1.5f;
    public string message1 = "First Message";

    public float waitTime2 = 1f;
    public string message2 = "Second Message";


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PrintMessages(waitTime1, waitTime2));


            // A downside to using string calls is that we can only pass 1 argument
            // (This code will cause an error)
            // If we want to stop the routine, we need to store its reference in a variable
            StartCoroutine("PrintMessages", waitTime1);
        }
    }

    // Coroutines can take arguments as well
    IEnumerator PrintMessages(float firstDelay, float secondDelay)
    {
        print("Starting message printing - " + Time.time.ToString("0.00"));

        // WaitForSeconds is scaled time
        yield return new WaitForSeconds(firstDelay);
        print(message1 + " - " + Time.time.ToString("0.00"));

        // Wait for another coroutine to finish before continuing this one
        yield return DoOtherStuff();
        print("back to printing messages - " + Time.time.ToString("0.00"));

        // WaitForSecondsRealtime is un-scaled time
        yield return new WaitForSecondsRealtime(secondDelay);
        print(message2 + " - " + Time.time.ToString("0.00"));
    }

    IEnumerator DoOtherStuff()
    {
        print("Doing other stuff - " + Time.time.ToString("0.00"));
        yield return new WaitForSeconds(3f);
    }
}
