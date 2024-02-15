using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 moveDirection; // The current move direction of the player
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        FlipSpriteBasedOnDirection();
        
    }

    // FixedUpdate is called at a fixed interval and is used for physics updates
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void FlipSpriteBasedOnDirection()
    {
        // Check the direction of movement to flip the sprite accordingly
        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = false; // Moving right, sprite looks to the right
        }
        else if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = true; // Moving left, sprite looks to the left
        }
        // When moveDirection.x is 0, the sprite's orientation remains as is (no flipping).
        // This means the sprite will face the last direction it moved in when stopping.
    }


}
