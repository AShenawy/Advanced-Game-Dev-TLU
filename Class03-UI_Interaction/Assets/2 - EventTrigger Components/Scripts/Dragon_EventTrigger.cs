using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;     // This namespace is required to use the BaseEventData parameter in the functions

public class Dragon_EventTrigger : MonoBehaviour
{
    private void Awake()
    {
        Image image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.05f;
    }

    // Note: You can name this function whatever you want, it's called by the Event Trigger
    // component just like a Button component
    public void TriggerOnDrop(BaseEventData eventData)
    {
        if (eventData is PointerEventData pointerEventData)
        {
            // Store a reference to the object being dropped
            var droppedObject = pointerEventData.pointerDrag;

            print($"{droppedObject.name} is dropped on {name}");
        }
    }
}
