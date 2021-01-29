using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 playerVelocity;

    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpSpeed = 1.0f;

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
        playerVelocity = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal") * playerSpeed, rb.velocity.y, Input.GetAxis("Vertical") * playerSpeed));;

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
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
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
