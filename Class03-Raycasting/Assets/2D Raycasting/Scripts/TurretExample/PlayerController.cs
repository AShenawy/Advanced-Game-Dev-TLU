using UnityEngine;

// This script handles controlling the player movement
public class PlayerController : MonoBehaviour
{
    // A reference to the Sprite Renderer componenet, holding the player image
    public SpriteRenderer playerImage;

    public float moveSpeed = 5f;

    // Reference to the main camera that we see the game world through
    private Camera mainCamera;

    // Half the width of the player's character image
    private float playerHalfWidth;

    // The game screen's right and left edges, used to block the player from going outside screen boundaries
    private float rightScreenEdge;
    private float leftScreenEdge;

    private float maxPosX;
    private float minPosX;

    // Start is called before the first frame update
    void Start()
    {
        // Get the main camera reference from the Camera class
        mainCamera = Camera.main;

        // Calculate the half-width from the player's image boundaries along the horizontal x-axis. The bounds are the total width so we split them in 2
        playerHalfWidth = playerImage.bounds.size.x * 0.5f;

        // Get the right-most point on the game screen which is its width (as 'mainCamera.pixelWidth'),
        // and project that point from the screen to the game world (using 'ScreenToWorldPoint' function from the main camera).
        // This gives us that same point's coordinates, but inside the game world where game objects also live and move
        rightScreenEdge = mainCamera.ScreenToWorldPoint(new Vector2(mainCamera.pixelWidth, 0)).x;

        // Do the same for the left-most point on the game screen, which happens to be 0 on the screen
        leftScreenEdge = mainCamera.ScreenToWorldPoint(Vector2.zero).x;

		// Calculate the maximum and minimum possible X values for the players position along the X-axis
		// Taking into account the player's own width so it stays completely on screen
        maxPosX = rightScreenEdge - playerHalfWidth;
        minPosX = leftScreenEdge + playerHalfWidth;
    }

    // Update is called once per frame
    void Update()
    {
        // Save the player input as GetAxis to tell which direction is pressed for the Horizontal key mapping (left/right)
        float inputHl = Input.GetAxis("Horizontal");
		
		// Save the players position at this moment in time
        Vector2 currentPos = gameObject.transform.position;

		// Check if the player pressed right direction (inputHl will be greater than 0)
		// AND also if the player's current position is still behind (x is less than) the maximum possible X position (the far right)
        if ((inputHl > 0) && (currentPos.x <= maxPosX))
        {
            // Calculate the player's new position by adding 1 unit to the right of the player's current position
            Vector2 newPos = currentPos + Vector2.right;

			// Apply the new position to the player's position property in the transform componenet
			// **Don't forget to multiplty the speed by Time.deltaTime to account for different computer hardware
            gameObject.transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);       
        }
		// Do the same as above, but mirrored for the left direction (note the opposite less than/greater than checks)
        else if (inputHl < 0 && (currentPos.x >= minPosX))
        {
            Vector2 newPos = currentPos + Vector2.left;

            gameObject.transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
        }
    }
}
