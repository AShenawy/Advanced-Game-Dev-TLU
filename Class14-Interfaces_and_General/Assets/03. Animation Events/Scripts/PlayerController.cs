using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 3f;
	public float jumpForce = 600f;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
	[SerializeField] private PlayerCombat combat;

	private bool canMove = true;
	private bool isGrounded;
	private bool isRunning;
	private bool isFacingRight = true;

	private Vector2 velocity;

    void Update()
    {
		if (canMove)
        {
			HandleMovement();
        }

		if (Input.GetKeyDown(KeyCode.LeftShift))
        {
			Attack();
        }
	}

	void Attack()
	{
		animator.SetTrigger("Attack");
        //combat.DisplayDamage();
    }

	void LateUpdate()
	{
		HandleLookDirection();
	}

    void HandleMovement()
    {
		// determine horizontal velocity change based on the horizontal input
		velocity.x = Input.GetAxisRaw("Horizontal");

		// Determine if running based on the horizontal movement
		if (velocity.x != 0)
		{
			isRunning = true;
		}
		else
		{
			isRunning = false;
		}

		// set the running animation state
		animator.SetBool("isRunning", isRunning);

		// get the current vertical velocity from the rigidbody component
		velocity.y = rigidbody.velocity.y;

		// Check to see if character is grounded by raycasting from the middle of the player
		// down to the groundCheck position and see if collided with gameobjects on the ground layer
		isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, groundMask);

		// Set the grounded animation states
		animator.SetBool("isGrounded", isGrounded);

		if (isGrounded && Input.GetButtonDown("Jump")) // If grounded AND jump button pressed, then allow the player to jump
		{
			// reset current vertical motion to 0 prior to jump
			velocity.y = 0f;
			// add a force in the up direction
			rigidbody.AddForce(new Vector2(0, jumpForce));
		}

		// If the player stops jumping mid jump and player is not yet falling
		// then set the vertical velocity to 0 (he will start to fall from gravity)
		if (Input.GetButtonUp("Jump") && velocity.y > 0f)
		{
			velocity.y = 0f;
		}

		// Change the actual velocity on the rigidbody
		rigidbody.velocity = new Vector2(velocity.x * moveSpeed, velocity.y);
	}

	void HandleLookDirection()
    {
		Vector3 localScale = transform.localScale;

		if (velocity.x > 0)
		{
			// moving right
			isFacingRight = true;
		}
		else if (velocity.x < 0)
		{
			// moving left
			isFacingRight = false;
		}

		// check to see if scale x is right for the player
		// if not, multiple by -1 which is an easy way to flip a sprite
		if ((isFacingRight && (localScale.x < 0)) || (!isFacingRight && (localScale.x > 0)))
		{
			localScale.x *= -1;
		}

		transform.localScale = localScale;
	}

	public void FreezePlayer(bool value)
    {
		// The not "!" assigns the inverse of "value" to "canMove"
		// so  FreezePlayer(true) will assign false to "canMove" and vice versa
		canMove = !value;
    }
}
