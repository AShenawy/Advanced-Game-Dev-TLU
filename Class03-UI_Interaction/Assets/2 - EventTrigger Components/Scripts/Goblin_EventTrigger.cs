using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;     // This namespace is required to use the BaseEventData parameter in the functions

public class Goblin_EventTrigger : MonoBehaviour
{
    private void Awake()
    {
        Image image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.5f;
    }

    // Functions called by Event Trigger components (just like the Button component & On Click)
    // ## Important: We need to add the BaseEventData type variable for the component to be able to call this function
    //               This data type is only available when including the 'using UnityEngine.EventSystems' namespace above
    public void TriggerClick(BaseEventData eventData)
    {
        print($"Clicked on {name} using trigger");
    }

    // Note: You can name all these function whatever you want, they're called by the Event Trigger
    // component just like a Button component
    public void TriggerBeginDrag(BaseEventData eventData)
    {
        // Check if the trigger happened using a pointing device (cursor, finger, stylus, etc.). Then case it to that data type
        if (eventData is PointerEventData pointerEvent)
        {
            // The type PointerEventData contains the 'pointerDrag' property, which isn't present in BaseEventData. Hence casting the data type
            print("Starting to drag with trigger object: " + pointerEvent.pointerDrag);

            // Disable the raycast target property to detect other UI objects under the dragged element
            GetComponent<Image>().raycastTarget = false;
        }
    }

    public void TriggerDrag(BaseEventData eventData)
    {
        if (eventData is PointerEventData pointerEvent)
        {
            print("Dragging with trigger object: " + pointerEvent.pointerDrag);

            // The type PointerEventData contains the 'delta' property which isn't present in BaseEventData. Hence casting the data type
            transform.position += (Vector3)pointerEvent.delta;
        }
    }

    public void TriggerEndDrag(BaseEventData eventData)
    {
        if (eventData is PointerEventData pointerEvent)
        {
            print("Ending drag with trigger object: " + pointerEvent.pointerDrag);

            // Enable the raycast target property to be able to detect drags and clicks on this object again
            GetComponent<Image>().raycastTarget = true;
        }
    }
}
