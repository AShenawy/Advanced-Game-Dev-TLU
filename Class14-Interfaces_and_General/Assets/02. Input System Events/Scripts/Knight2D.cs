using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight2D : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        print("clicked on " + gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        print("Pointer entered Knight!");
    }

    private void OnMouseDown()
    {
        
    }
}
