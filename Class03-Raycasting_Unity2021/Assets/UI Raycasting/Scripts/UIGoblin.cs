using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // This namespace is required to use the below interfaces

public class UIGoblin : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{

    // OnBeginDrag is called only 1 time when we hold and start dragging the game object
    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;
        print("Begin dragging " + draggedObject.name);
    }

    // OnDrag is continuosuly called as long as we're dragging the game object
    public void OnDrag(PointerEventData eventData)
    {
        print("Dragging");
        transform.position += (Vector3)eventData.delta;
    }

    // OnEndDrag is called only 1 time when we let go and stop dragging the game object
    public void OnEndDrag(PointerEventData eventData)
    {
        var draggedObject = eventData.pointerDrag;
        print("End dragging " + draggedObject.name);
    }

    // OnDrop is called on this game object when we drop / end dragging on it with a mouse
    // Important!! This script is not called on the object being dragged, but the object the drag is ended on
    // So if we dragged ObjA and _dropped_ it on ObjB, OnEndDrag (if used) is called on ObjA & OnDrop (if used) is called on ObjB,
    // this means that OnDrop should be placed not on the draggable object, but the object that the draggable will be dropped on.
    // More info: https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IDropHandler.html
    public void OnDrop(PointerEventData eventData)
    {
        print("I've been dropped!");
    }

    // OnPointerClick is called when a full click occurs. E.g.: mouse button both pressed and let go while on top of game object
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Clicked!");
    }
}
