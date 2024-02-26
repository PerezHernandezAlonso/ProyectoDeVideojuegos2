using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves left and right
    public float depthMoveSpeed = 3f; // Speed at which the player moves in the Z axis
    public float verticalMoveSpeed = 3f; // Speed at which the player moves up and down
    public Vector2 zAxisLimits = new Vector2(-5f, 5f); // Limits for movement along the Z axis
    public Vector2 yAxisLimits = new Vector2(-3f, 3f); // Limits for movement along the Y axis
    public Vector2 xAxisLimits = new Vector2(-10f, 10f);



    private Rigidbody rb; // Reference to the Rigidbody component
    private Vector3 moveDirection; // The current move direction of the player, including depth
    private float verticalMovement = 0f; // Separate variable for vertical movement
    private SpriteRenderer spriteRenderer; // To flip the sprite based on direction




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        ClampPosition();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical") * verticalMoveSpeed; // For vertical movement
        float moveZ = Input.GetAxis("Vertical") * depthMoveSpeed; // For depth movement

        moveDirection = new Vector3(moveX, moveY, moveZ);
    }

    void ClampPosition()
    {
        // Clamp the character's position within the specified limits
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, xAxisLimits.x, xAxisLimits.y);
        pos.z = Mathf.Clamp(pos.z, zAxisLimits.x, zAxisLimits.y);
        pos.y = Mathf.Clamp(pos.y, yAxisLimits.x, yAxisLimits.y);
        transform.position = pos;
    }
    void Move()
    {
        Vector3 movement = new Vector3(moveDirection.x * moveSpeed, moveDirection.y, moveDirection.z);
        rb.velocity = movement;
    }

    void FlipSpriteBasedOnDirection()
    {
        // Flip sprite based on the direction of the X-axis movement
        if (moveDirection.x < 0)
            spriteRenderer.flipX = false; // Moving right
        else if (moveDirection.x > 0)
            spriteRenderer.flipX = true; // Moving left
    }


}
