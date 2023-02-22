using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This scripts detects mouse clicks on objects in 3D Physics
public class ClickFromCamera3D : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask interactMask;

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
        // Interaction mask allows us to filter what objects the ray should register
        bool isHit = Physics.Raycast(clickRay, out hit, 100f, interactMask);

        if (isHit)
        {
            print(hit.transform.name);

            // Do other logic with the object we clicked on
            RandomiseColor random = hit.transform.GetComponent<RandomiseColor>();

            if (random != null)
            {
                random.Randomise();
            }
        }
        else
        {
            print("Nothing clicked!");
        }


        // Project the click screen position to in-game world position
        Vector3 clickOrigin = mainCamera.ScreenToWorldPoint(new Vector3(clickPosition.x, clickPosition.y, 0f));

        // Draw editor debugger to see ray in action
        Debug.DrawRay(clickOrigin, clickRay.direction * 100f, Color.yellow, 0.5f);
    }
}
