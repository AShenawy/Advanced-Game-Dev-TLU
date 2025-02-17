using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISquareSnap : MonoBehaviour, IDropHandler
{
    public Transform dropTransform;

    public void OnDrop(PointerEventData eventData)
    {
        // Store a reference to the dropped object
        var droppedObject = eventData.pointerDrag;
        print(droppedObject.name + " is dropped on me");

        // We set a condition (if we like) to only accept snapping into place an object with a specific script
        // Otherwise, the object won't snap
        if (droppedObject.GetComponent<UIGoblin>())
        {
            droppedObject.transform.position = dropTransform.position;
        }
    }
}