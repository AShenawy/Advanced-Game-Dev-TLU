using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrag : MonoBehaviour
{
    Vector3 clickOffset;

    private void OnMouseDown()
    {
        print("Mouse down on " + name);

        // Calculate the offset (distance) between the cursor position and the object position (in world space)
        // We do this on the first click down because it's not needed every frame while dragging (it'll always be the same value)
        clickOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }


    void OnMouseDrag()
    {
        print("Dragging " + name);

        // Store the click position in world coordinates, adjusted by the click offset
        var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - clickOffset;

        // Make the click position Z same as the dragged object's, to not change the object's depth/distance from camera
        newPos.z = transform.position.z;

        // Apply the new mouse position to the object to create the drag effect
        transform.position = newPos;
    }

    private void OnMouseUp()
    {
        print("Mouse up on " + name);
    }
}
