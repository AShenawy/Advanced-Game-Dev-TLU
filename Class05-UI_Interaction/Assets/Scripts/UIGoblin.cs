using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // This namespace is required to use the below interfaces

public class UIGoblin : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    // The difference between where a pointer is located when dragging and the pivot point of the game object
    Vector2 pressToPivotDifference;

    // OnBeginDrag is called only 1 time when we hold and start dragging the game object
    public void OnBeginDrag(PointerEventData eventData)
    {
        // The position of the pointer (mouse, tap, etc.) when the drag started
        Vector2 pressPos = eventData.position;

        pressToPivotDifference = (Vector2)transform.position - pressPos;
    }

    // OnDrag is continuosuly called as long as we're dragging the game object
    public void OnDrag(PointerEventData eventData)
    {
        print("Dragging");

        // If dragging, move the game object to where the pointer is, while compensating for the "shift"
        // between game object's pivot and the pointer's position
        transform.position = eventData.position + pressToPivotDifference;
    }

    // OnEndDrag is called only 1 time when we let go and stop dragging the game object
    public void OnEndDrag(PointerEventData eventData)
    {
        print("Dragging Ended!");
    }

    // OnDrop is called on this game object when we drop / end dragging on it with a mouse
    // Important!! This script is not called on the object being dragged, but the object the drag is ended on
    // So if we dragged ObjA and _dropped_ it on ObjB, OnEndDrag (if used) is called on ObjA & OnDrop (if used) is called on ObjB,
    // this means that OnDrop should be placed not on the draggable object, but the object that the draggable will be dropped on.
    // More info: https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IDropHandler.html
    public void OnDrop(PointerEventData eventData)
    {
        print("Dropped something on me!");
    }

    // OnPointerClick is called when a full click occurs. E.g.: mouse button both pressed and let go while on top of game object
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Clicked!");
    }
}
