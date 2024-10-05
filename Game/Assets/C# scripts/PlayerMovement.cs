using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick joystick;  // Reference to your joystick
    public float moveSpeed = 5f;     // Character movement speed
    public Animator animator;        // Animator for controlling animations
    private Rigidbody rb;            // Rigidbody for physics-based movement
    private bool canMove = false;    // Boolean to check if player can move

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Initially set canMove to false, preventing the player from moving
        canMove = false;
    }
    private void Update()
    {
        //if (!canMove)
        //{
        //    // Prevent movement if canMove is false
        //    return;
        //}

        // Get joystick input
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Movement vector
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Debug.Log(direction.magnitude);
        // Check if the character is moving
        if (direction.magnitude >= 0.1f)
        {
            // Calculate target angle and rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);

            // Move character
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
            Debug.Log(direction);

            // Control animations based on the speed
            animator.SetFloat("Speed", direction.magnitude);

            // Control run and walk based on joystick input strength
            if (direction.magnitude > 3f)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            // Set speed to 0 if no input
            animator.SetFloat("Speed", 0f);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }

    


    // Function to allow movement again after clicking the Go button
    public void EnableMovement()
    {
        canMove = true;
    }

    // Example of triggering a lift action
    public void LiftObject()
    {
        animator.SetTrigger("Lift");
    }

    // Example of triggering a jump action
    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    // Example of triggering a pick up action
    public void PickUp()
    {
        animator.SetTrigger("PickUp");
    }
}