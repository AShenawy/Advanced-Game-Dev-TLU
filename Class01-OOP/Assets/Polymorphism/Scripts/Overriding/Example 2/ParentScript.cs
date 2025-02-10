using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour
{
    // Unity allows us to also make the Awake, Start, Update, etc. functions
	// virtual to be overridden by their child classes
    public virtual void Start()
    {
        print("Hello! I'm the " + name);
    }

    void Update()
    {
        
    }
}
