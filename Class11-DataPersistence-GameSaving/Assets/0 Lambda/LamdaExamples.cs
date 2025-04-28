using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LamdaExamples : MonoBehaviour
{
    // ========== PROPERTIES ===========

    private string playerName;

    // Lambda can be used for properties. This is a get only property
    public string PlayerNameLambdaGetter => playerName;

    // Shorthand of writing a full getter
    public string PlayerNameNormalGetter
    {
        get
        {
            return playerName;
        }
    }

    // Can also be used for both Getter and Setter
    // Note there are no braces
    public string PlayerNameGetterSetterLambda
    {
        get => playerName;
        set => playerName = value;
    }


    // ========== FUNCTIONS ===========

    // Another form of Lambda Expression is a shortend function
    // Note we don't have braces or "return" if it's in one line.
    public int AddNormal(int a, int b)
    {
        return a + b;
    }
    
    public int AddLambda(int a, int b) => a + b;


    // ========== ANONYMOUS FUNCTIONS ===========

    public class Player
    {
        public string name;
        public int ID;
        // other player data...
    }

    // Another form of methods using Lambda/ Fat Arrow operator are anonymous functions
    // Anonymous methods don't have a name and are meant to be only called once and thrown away
    List<Player> players = new List<Player>();

    
    // Regular function to get player by name
    public Player GetPlayerByNameNormalFunction(string playerName)
    {
        Player foundPlayer = null;

        // The normal way is either using a for loop or a foreach loop
        foreach (Player player in players)
        {
            if (player.name == playerName)
            {
                foundPlayer = player;
                break;
            }
        }

        return foundPlayer;
    }
    
    // Using anonymous function/expression to take advantage of List's methods
    public Player GetPlayerByNameAnonymousFunction(string playerName)
    {
        // We can use an Anonymous Method for in-line use and to throw away after we're done,
        // as it won't be used anywhere else except in this case
        
        Player foundPlayer = players.Find(p => p.name == playerName);
        
        return foundPlayer;
    }


    // ========== CALLBACKS ===========

    // We also use anonymous methods as "callback" functions
    // Meaning that we provide a function that does things. However, this function is not called right away
    // Instead, it's called only when something happens during play, where we can't manually call it because we don't know when it's needed
    // Buttons are a perfect example

    Button myButton;

    void SetupButtonWhenClicked()
    {
        // We want some functionality to only happen once button is clicked
        // We give it an anonymous functin as a delegate to be called at that time

        // A one-liner callback. We call a function
        myButton.onClick.AddListener(DoSomething);


        // Another one-liner. We change a value
        int someNumber;
        myButton.onClick.AddListener(() => someNumber = 42);



        // If we need to do multiple things, we can use braces and semi-colons to add more lines
        myButton.onClick.AddListener(() =>
        {
            GetPlayerByNameAnonymousFunction("Doggo");
            AddLambda(2, 4);
        });
    }

    void DoSomething()
    {

        // Doing something...
    }
}

