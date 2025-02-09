using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the player to shoot projectiles by instantiating them during run-time/gameplay
public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float firingRate = 0.5f;

    private float fireTime;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D;
        hit2D = Physics2D.Raycast(transform.position, Vector2.down);

        // If the raycast hit a collider, and the collider game object tag is the player's then we can shoot
        if (hit2D && hit2D.transform.CompareTag("Player"))
        {
            // A second check to limit how fast we can fire
            if (Time.time >= fireTime)
            {
                Shoot();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.down * 20f);
    }

    void Shoot()
    {
        print("Shooting at player!");
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        fireTime = Time.time + firingRate;
    }
}
