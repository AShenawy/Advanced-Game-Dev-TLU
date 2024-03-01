using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DotProduct : MonoBehaviour
{
    public float dotValue;
    public TMP_Text textValue;
    public Transform playerTransform;

    private void Awake()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindWithTag("Player").transform;

            if (playerTransform == null)
            {
                Debug.LogError("No player assigned or player tag in scene");
            }
        }
    }


    void Update()
    {
        // Get the vector the points from the enemy to the player
        Vector2 directionVector = playerTransform.position - transform.position;

        // Normalise the direction vector to exclude its magnitude from calculations
        Vector2 normalizedDirection = directionVector.normalized;

        // The dot product is currently based on the assumption that the enemy is always
        // looking UP (the left hand side of Dot calculation)
        float dotProductForUp = Vector2.Dot(Vector2.up, normalizedDirection);

        // If the enemy moves around they won't always be looking up, so we need to
        // account for the enemy game object's own forward axis
        Vector2 enemyFaceDirection = transform.TransformDirection(Vector2.up);
        float dotProductForEnemyFace = Vector2.Dot(enemyFaceDirection, normalizedDirection);

        dotValue = dotProductForEnemyFace;
        textValue.text = dotValue.ToString();
    }
}
