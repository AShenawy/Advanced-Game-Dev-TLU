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
        }
    }

    // Coroutines can take arguments as well!
    IEnumerator PrintMessages(float firstDelay, float secondDelay)
    {
        print("Starting coroutine at " + Time.time);

        yield return new WaitForSeconds(firstDelay);
        print(message1 + " at " + Time.time);

        yield return new WaitForSeconds(secondDelay);
        print(message2 + " at " + Time.time);
    }
}
