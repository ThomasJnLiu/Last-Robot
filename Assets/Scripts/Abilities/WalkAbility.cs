using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAbility : MonoBehaviour
{
    private PlayerController player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        player.rb.angularVelocity = Vector3.zero;
        Vector3 move = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        // I have no idea why, but removing the first 2 "* playerSpeed" makes the movement while jumping stuttery, so don't touch that
        player.playerVelocity = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal") * player.playerSpeed, player.rb.velocity.y, Input.GetAxis("Vertical") * player.playerSpeed))*player.playerSpeed;

        // Calculates the angle the player should be facing
        float targetAngle = Mathf.Atan2(player.playerVelocity.x, player.playerVelocity.z) * Mathf.Rad2Deg;        
        // Calculates the direction the player should be moving in, using the angle the player is facing
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * player.transform.forward;
        
        if(player.canTurn){
            // Calculates the angle the player should be facing, taking into consideration the position of the camera
            targetAngle = Mathf.Atan2(player.playerVelocity.x, player.playerVelocity.z) * Mathf.Rad2Deg + player.cam.eulerAngles.y;        
            // Calculates the direction the player should be moving in, using the angle the player is facing
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        // Move
        if (player.playerVelocity.x != 0f || player.playerVelocity.z != 0f)
        {
            PlayerSoundController.PlayWalk(true);
            // Turns the player in the direction they're moving in
            float angle = Mathf.SmoothDampAngle(player.transform.eulerAngles.y, targetAngle, ref player.turnSmoothVelocity, player.turnSmoothTime);
            player.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // gameObject.transform.forward = move;
            player.animator.SetBool("isRunning", true);
        } else {
            PlayerSoundController.PlayWalk(false);
            player.animator.SetBool("isRunning", false);
        }

        // Stops the model immediately if there is no input from the player, prevents sliding
        if (Input.GetAxis("Horizontal") != 0f ||Input.GetAxis("Vertical") != 0f) {
            player.rb.velocity = new Vector3(moveDir.x * player.playerSpeed, player.rb.velocity.y, moveDir.z * player.playerSpeed);
        } else {
            player.rb.velocity = new Vector3(0, player.rb.velocity.y, 0);
        }
    }
    
    
}
