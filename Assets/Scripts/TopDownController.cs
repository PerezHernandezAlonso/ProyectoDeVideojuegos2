using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 moveDirection; // The current move direction of the player

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component from the GameObject this script is attached to
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Process inputs from the keyboard
        ProcessInputs();
    }

    // FixedUpdate is called at a fixed interval and is used for physics updates
    void FixedUpdate()
    {
        // Move the player
        Move();
    }

    void ProcessInputs()
    {
        // Get horizontal and vertical input (arrow keys or WASD)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Set the move direction based on the input
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        // Apply the movement to the player's Rigidbody2D component
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
