using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrag : MonoBehaviour
{
    void OnMouseDrag()
    {
        // Store the click position in world coordinates
        var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Make the click position Z same as the dragged object's, to not change the object's depth/distance from camera
        newPos.z = transform.position.z;

        // Apply the new mouse position to the object to create the drag effect
        transform.position = newPos;
    }
}
