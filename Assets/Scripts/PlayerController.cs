using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 playerVelocity;

    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpSpeed = 10.0f;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = Vector3.zero;

        Vector3 move = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        // I have no idea why, but removing the first 2 "* playerSpeed" makes the movement while jumping stuttery, so don't touch that
        playerVelocity = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal") * playerSpeed, rb.velocity.y, Input.GetAxis("Vertical") * playerSpeed))*playerSpeed;

        // Calculates the angle the player should be facing
        float targetAngle = Mathf.Atan2(playerVelocity.x, playerVelocity.z) * Mathf.Rad2Deg;

        // Y Velocity
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            Debug.Log("what");
        } else {
            playerVelocity.y = rb.velocity.y;
            Debug.Log("fuck " + rb.velocity);
        }

        // Move
        if (playerVelocity.x != 0f || playerVelocity.z != 0f)
        {
            // Turns the player in the direction they're moving in
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // gameObject.transform.forward = move;
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = playerSpeed;
        }

        rb.velocity = playerVelocity;
    }

    // Check if object is grounded
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == gameObject)
        {
            return;
        }

        groundedPlayer = true;
    }

    // Check if the object is in the air
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == gameObject)
        {
            return;
        }

        groundedPlayer = false;
    }
}
