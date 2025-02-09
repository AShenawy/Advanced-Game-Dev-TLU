using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the behaviour of the projectile game object
public class ProjectileBehaviour : MonoBehaviour
{
	// How fast will the project travel
    public float speed;
	
	// How much time, in seconds, before the projectile destroys itself (if it hits nothing and escapes the play area)
    public float destroyAfter = 2f;

    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }

    void Update()
    {
		// As soon as the projectile is instantiated in the game scene, transform.Translate will start
		// moving it down one unit, multiplied by the speed and Time.deltaTime for cpu optimisation
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
