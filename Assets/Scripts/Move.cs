using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour
{
    [Header("Movement Parameters")]
    public float moveSpeed = 5f;           // Horizontal movement speed
    public float jumpForce = 500f;         // Jump force
    public float groundCheckRadius = 0.2f; // Ground check radius for isGrounded
    public LayerMask groundLayers;         // Layers considered ground

    [Header("Components")]
    public Rigidbody2D rb;               // Rigidbody2D component reference
    public Transform groundCheck;        // Ground check transform reference

    private bool isGrounded;              // Whether the player is grounded

    void Start()
    {
        // Ensure Rigidbody2D and groundCheck are set
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not assigned to PlayerMovement script!");
        }
        if (groundCheck == null)
        {
            Debug.LogError("Ground check transform not assigned to PlayerMovement script!");
        }
    }

    void Update()
    {
        // Basic ground check based on Physics2D.OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        // Handle horizontal movement (consider using `Vector2.MoveTowards` for smoothing)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Adjust facing direction based on movement
        if (horizontalInput > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }
        else if (horizontalInput < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }

        // Handle jumping using `if (isGrounded)` for accurate ground detection
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
