using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragon : MonoBehaviour, IDropHandler
{
    // OnDrop is called on this game object when we drop / end dragging on it with a mouse
    // Important!! This script is not called on the object being dragged, but the object the drag is ended on
    // So if we dragged ObjA and _dropped_ it on ObjB, OnDrop (if used) is called first on ObjB, and OnEndDrag (if used) is called second on ObjA
    // this means that OnDrop should be placed not on the draggable object, but the object that the draggable will be dropped on.
    // More info: https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IDropHandler.html
    public void OnDrop(PointerEventData eventData)
    {
        // Store a reference to the object being dropped
        var droppedObject = eventData.pointerDrag;

        print(droppedObject.name + " is dropped on me");
    }
}
