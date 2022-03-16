using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedHello : MonoBehaviour
{
    public float waitTime = 1.5f;

    // Start is called before the first frame update
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
            
        }
    }

    IEnumerator SayHelloAfter()
    {
        print("Gonna say hello!");

        // Stop execution using a yield and WaitForSeconds object
        yield return new WaitForSeconds(waitTime);

        // Continue execution
        print("Hello!");
    }
}
