using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // This namespace is required to use the below interfaces
using UnityEngine.UI;

public class UIGoblin : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    private void Awake()
    {
        // Prevent the transparent parts of the UI Image from triggering pointer events
        // ## Important: For this to work, make sure Read/Write is enabled in the sprite's import settings in Unity
        Image image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.05f;
    }


    /* ## To be used with the Event Trigger component in Unity
    public void TriggerClick(BaseEventData eventData)
    {
        print("Used trigger click");
    }

    public void TriggerBeginDrag(BaseEventData eventData)
    {
        if (eventData is PointerEventData pointerEvent)
        {
            print("starting to drag with trigger" + pointerEvent.pointerDrag);
        }
    }
    */

    // OnPointerClick is called only when we do a full click (button down and up) on the same object
    // Docs ref: https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IPointerClickHandler.html
    public void OnPointerClick(PointerEventData eventData)
    {
        print("clicked on " + name);
    }


    // OnBeginDrag is called only once when we hold and start dragging the game object
    // If we don't drag, it won't get called
    // Docs ref: https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IBeginDragHandler.html
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store a reference to the object being dragged
        GameObject draggedObject = eventData.pointerDrag;
        print("Begin dragging " + draggedObject.name);

        // Disable the raycast target property to detect other UI objects under the dragged element
        GetComponent<Image>().raycastTarget = false;
    }

    // OnDrag is continuosuly called as long as we're dragging the game object
    // Docs ref: https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IDragHandler.html
    public void OnDrag(PointerEventData eventData)
    {
        print($"Dragging {eventData.pointerDrag.name}...");

        // Increment the position value by the mouse delta (difference in mouse position from previous frame to current frame)
        transform.position += (Vector3)eventData.delta;
    }

    // OnEndDrag is called only once when we let go and stop dragging the game object
    // Docs ref: https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IEndDragHandler.html
    public void OnEndDrag(PointerEventData eventData)
    {
        // Store a reference to the object being dragged
        var draggedObject = eventData.pointerDrag;

        print("End dragging " + draggedObject.name);

        // Enable the raycast target property to be able to detect drags and clicks on this object again
        GetComponent<Image>().raycastTarget = true;
    }
}
