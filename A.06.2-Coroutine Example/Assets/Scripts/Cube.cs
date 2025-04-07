using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Right,
    Left
}

public class Cube : MonoBehaviour
{
    public Direction moveDirection;
    public float moveSpeed = 8f;
    public float maxDistanceX = 3f;
    public float maxDistanceY = 3f;

    public Vector3 positionStart;
    public TMP_Text directionText;

    void Start()
    {
        positionStart = transform.position;
        directionText.text = moveDirection.ToString();
        StartCoroutine(AnimateMovementCR());
    }

    IEnumerator AnimateMovementCR()
    {
        Vector3 positionEnd = GetFinalPosition();

        while (transform.position != positionEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionEnd, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = positionEnd;

        while (transform.position != positionStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionStart, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = positionStart;
        StartCoroutine(AnimateMovementCR());
    }

    Vector3 GetFinalPosition()
    {
        Vector3 positionFinal = positionStart;

        switch (moveDirection)
        {
            case Direction.Up:
                positionFinal += new Vector3(0f, maxDistanceY, 0f);
                break;

            case Direction.Down:
                positionFinal += new Vector3(0f, -maxDistanceY, 0f);
                break;

            case Direction.Right:
                positionFinal += new Vector3(maxDistanceX, 0f, 0f);
                break;

            case Direction.Left:
                positionFinal += new Vector3(-maxDistanceX, 0f, 0f);
                break;

            default:
                Debug.LogError("Undefined direction");
                break;
        }

        return positionFinal;
    }

    public void SetDirection(int directionByNumber)
    {
        if (directionByNumber > 3 || directionByNumber < 0)
        {
            Debug.LogError("Undefined direction value");
            return;
        }

        moveDirection = (Direction)directionByNumber;
        directionText.text = moveDirection.ToString();
    }
}
