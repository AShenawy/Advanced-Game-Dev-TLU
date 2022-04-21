using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float speed = 25f;
    public float minX;
    public float maxX;

    private Vector2 startingPosition;
    private bool isMovingRight = true;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
    }

    void Update()
    {
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= maxX)
            {
                isMovingRight = false;
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= minX)
            {
                isMovingRight = true;
                spriteRenderer.flipX = false;
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = startingPosition;
    }
}
