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
            //StartCoroutine(PrintMessages(waitTime1, waitTime2));
            StartCoroutine(Corout1());
        }
    }

    // Coroutines can take arguments as well!
    IEnumerator PrintMessages(float firstDelay, float secondDelay)
    {
        print("Starting message printing - " + Time.time.ToString("0.00"));

        // WaitForSeconds is scaled time
        yield return new WaitForSeconds(firstDelay);
        print(message1 + " - " + Time.time.ToString("0.00"));

        yield return DoOtherStuff();
        print("back to printing messages - " + Time.time.ToString("0.00"));

        // WaitForSecondsRealtime is un-scaled time
        yield return new WaitForSecondsRealtime(secondDelay);
        print(message2 + " - " + Time.time.ToString("0.00"));
    }

    IEnumerator DoOtherStuff()
    {
        print("Doing other stuff - " + Time.time.ToString("0.00"));
        yield return new WaitForSeconds(1f);
    }


    IEnumerator Corout1()
    {
        StartCoroutine("Corout2");
        yield return new WaitForSeconds(2f);
        StopCoroutine("Corout2");
    }

    int counter = 0;
    IEnumerator Corout2()
    {
        while (true)
        {
            print(counter);
            counter++;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
