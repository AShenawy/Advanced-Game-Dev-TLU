using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFromCamera2D : MonoBehaviour
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
        Vector3 screenClickPosition = Input.mousePosition;

        // Convert click point on screen into an in-game world point
        Vector2 worldClickPosition = mainCamera.ScreenToWorldPoint(screenClickPosition);

        // Declare a variable to store the Raycast hit information
        RaycastHit2D hit2d;

        // Physics2D.Raycast returns the result from casting the ray - which can be empty (null)
        hit2d = Physics2D.Raycast(worldClickPosition, Vector2.zero);

        if (hit2d)
        {
            print("Clicked on " + hit2d.transform.name);

            // See if the hit object is a goblin by looking for the GoblinScript on it
            GoblinScript goblin = hit2d.transform.GetComponent<GoblinScript>();

            // If we did get a GoblinScript, then we can call the functions in it
            if (goblin != null)
            {
                goblin.Shout();

            }
            else
            {
                print("Not a goblin");
            }
        }
        else
        {
            print("Nothing clicked!");
        }
    }
}
