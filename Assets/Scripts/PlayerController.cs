using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 playerVelocity;

    public Transform cam;

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

        // Calculates the angle the player should be facing, taking into consideration the position of the camera
        float targetAngle = Mathf.Atan2(playerVelocity.x, playerVelocity.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

        // Calculates the direction the player should be moving in, using the angle the player is facing
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        // I uncommented this code, if it breaks anything, put it back 

        // Y Velocity
        // if (groundedPlayer && playerVelocity.y < 0)
        // {
        //     playerVelocity.y = 0f;
        // } else {
        //     playerVelocity.y = rb.velocity.y;
        // }

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

        // Changes the height position of the player.
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // this is extremely messy, but it works and that's what matters :)
            rb.velocity = new Vector3(rb.velocity.x, 10f, rb.velocity.z);
            playerVelocity = rb.velocity;
            Debug.Log(playerVelocity.y);
        }

        // // Stops the model immediately if there is no input from the player, prevents sliding
        if (Input.GetAxis("Horizontal") != 0f ||Input.GetAxis("Vertical") != 0f){
            rb.velocity = new Vector3(moveDir.x * playerSpeed, rb.velocity.y, moveDir.z * playerSpeed);
        }else{
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
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
