using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // This namespace is required to use the below interfaces
using UnityEngine.UI;

public class UIGoblin : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // OnBeginDrag is called only once when we hold and start dragging the game object
    // If we don't drag, it won't get called
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store a reference to the object being dragged
        GameObject draggedObject = eventData.pointerEnter;
        print("Begin dragging " + draggedObject.name);

        // Disable the raycast target property to detect UI objects under the dragged element
        GetComponent<Image>().raycastTarget = false;
    }

    // OnDrag is continuosuly called as long as we're dragging the game object
    public void OnDrag(PointerEventData eventData)
    {
        print("Dragging");

        // Increment the position value by the mouse delta (difference in mouse position from previous frame to current frame)
        transform.position += (Vector3)eventData.delta;
    }

    // OnEndDrag is called only once when we let go and stop dragging the game object
    public void OnEndDrag(PointerEventData eventData)
    {
        // Store a reference to the object being dragged
        var draggedObject = eventData.pointerDrag;

        print("End dragging " + draggedObject.name);

        // Enable the raycast target property to be able to detect drags and clicks on this object again
        GetComponent<Image>().raycastTarget = true;
    }

    // OnPointerClick is called when a full click occurs. I.E. mouse button is pressed and let go of while on top of the same game object
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Clicked!");
    }
}
