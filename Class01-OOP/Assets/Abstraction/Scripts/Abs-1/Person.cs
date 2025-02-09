using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public string firstName;
    public string lastName;
    public int birthYear;

    public string GetFullName()
    {
        string fullName = firstName + " " + lastName;
        return fullName;
    }

    public int GetAge()
    {
        // The DateTime class and the System namespace belong to the standard C# language libraries
        // They allow us to get the time on our machine's operating system just like the clock
        return System.DateTime.Now.Year - birthYear;
    }
}