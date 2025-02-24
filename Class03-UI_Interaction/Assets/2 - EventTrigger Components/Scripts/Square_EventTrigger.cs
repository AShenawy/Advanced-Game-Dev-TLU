using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;     // This namespace is required to use the BaseEventData parameter in the functions

public class Square_EventTrigger : MonoBehaviour
{
    public Transform dropTransform;

    // Note: You can name this function whatever you want, it's called by the Event Trigger
    // component just like a Button component
    public void TriggerOnDrop(BaseEventData eventData)
    {
        if (eventData is PointerEventData pointerEventData)
        {
            // Store a reference to the dropped object
            var droppedObject = pointerEventData.pointerDrag;
            print($"{droppedObject.name} is dropped on {name}");

            // We set a condition (if we like) to only accept snapping into place an object with a specific script
            // Otherwise, the object won't snap
            if (droppedObject.GetComponent<Goblin_EventTrigger>())
            {
                droppedObject.transform.position = dropTransform.position;
            }
        }
    }
}