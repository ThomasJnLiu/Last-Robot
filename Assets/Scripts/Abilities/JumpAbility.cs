using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAbility : MonoBehaviour
{
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        // Changes the height position of the player.
        if (Input.GetButtonDown("Jump") && player.groundedPlayer)
        {
            // this is extremely messy, but it works and that's what matters :)
            player.rb.velocity = new Vector3(player.rb.velocity.x, 10f, player.rb.velocity.z);
            player.playerVelocity = player.rb.velocity;
            PlayerSoundController.PlayOneTime("jump");
            Debug.Log(player.playerVelocity.y);
        }
    }
}
