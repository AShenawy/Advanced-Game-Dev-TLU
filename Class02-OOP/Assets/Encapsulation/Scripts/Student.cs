using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    // Private variables are inaccessible to other classes/objects and
    // Unity doesn't show them in the Inspector either. But adding
    // the [SerializeField] property makes them show up in the Inspector window
    [SerializeField]
    private string myUsername = "Fruit Loop";

    [SerializeField]
    private string myPassword = "12345";


    // ######        PROPERTIES          #######

    // Properties are variables that act like functions, making them more flexible
    // One advantage of functions and properties is that we can validate the new value before
    // we assign it to a variable. Something that isn't available when using variables directly
    public string Username
    {
        // The "getter" part determines what the property gives back (returns) when used
        get
        {
            return myUsername;
        }

        // The "setter" part determines what happens if we assign the property a new value
        set
        {
            // The setter part also has a "value" variable, containing the value we are to assign
            // This "value" is a keyword by C# language and we can't change its name
            if (value.Length <= 0)
            {
                // If value is empty, print a message to console and skip assignment
                print("The new username cannot be blank!");
                return;
            }

            myUsername = value;
        }
    }


    // ######       AUTOMATIC PROPERTIES          #######

    // Automatic properties mean we only declare whether they're 'get', 'set', or both. They have no body like above
    // Since the property has no body, it returns nothing if we don't assign it a value somewhere else in the code, or
    // we can initialise it with a value just like our variables
    public string UsernameAutoProperty { get; set; } = "Initial value";


    // This property's value is accessible from anywhere (is public and has 'get')
    // but its value is only set inside its class (has 'private set')
    public string PasswordAutoProperty { get; private set; }


    // This property can only be set from other classes (is public variable and has 'set')
    // but its value is only accessible from inside its class (has 'private get')
    public int OnlyPublicSetProperty { private get; set; }



    // ######       FUNCTIONS          #######

    // Using functions is another way to get or set values of private variables
    public string GetUsername()
    {
        return myUsername;
    }


    // One advantage of functions and properties is that we can validate the new value before
    // we assign it to a variable. Something that isn't available when using variables directly
    public void SetUsername(string newName)
    {
        // If new name is empty, print a message to console and skip assignment
        if (newName.Length <= 0)
        {
            print("The new username cannot be blank!");
            return;
        }

        myUsername = newName;
    }


    public string GetPassword()
    {
        return myPassword;
    }

    
    public void SetPassword(string newPassword)
    {
        // If new password isn't different, print a message and skip assignment
        if (newPassword == myPassword)
        {
            print("The new password must be a different password!");
            return;
        }

        myPassword = newPassword;
    }
}
