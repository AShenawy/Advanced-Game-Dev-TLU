using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This scripts detects mouse clicks on objects in 3D Physics
public class ClickFromCamera3D : MonoBehaviour
{
    public Camera mainCamera;

    void Update()
    {
        // Only check when the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClicked();
        }
    }

    void OnMouseClicked()
    {
        // Get the click position on screen
        Vector3 clickPosition = Input.mousePosition;

        // Create a ray starting at click point on screen and moves along the camera perspective
        Ray clickRay = mainCamera.ScreenPointToRay(clickPosition);
        
        // Declare a variable to store the Raycast hit information
        RaycastHit hit;

        // Physics.Raycast returns a bool (true/false) whether it hit a collider or not
        if (Physics.Raycast(clickRay, out hit))
        {
            print(hit.transform.name);
            
            // Do other logic with the object we clicked on
        }
        else
        {
            print("Nothing clicked!");
        }


        // Project the click screen position to in-game world position
        Vector3 clickOrigin = mainCamera.ScreenToWorldPoint(new Vector3(clickPosition.x, clickPosition.y, 0f));

        // Draw editor debugger to see ray in action
        //Debug.DrawRay(clickOrigin, clickRay.direction * 100f, Color.yellow, 0.5f);
    }
}
