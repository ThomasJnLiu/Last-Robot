using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAbility : MonoBehaviour
{
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        // Grab button
        if (Input.GetKeyDown ("c")) {
            if(player.canGrab && !player.grabbingItem) {
                // Setting a lot of variables here, we could conslidate this into a function so it's a little cleaner, esp since these same variables
                // are also changed in the next else condition
                player.grabbingItem = true;
                player.canTurn = true;
                // player.playerSpeed = 5f;
                player.box.transform.SetParent(player.transform, true);
                player.box.GetComponent<Rigidbody>().isKinematic = true;

                // was having some buggy behaviour when the player's collider intersected with the box's collider
                // by setting the box collider to a trigger, it makes it so other colliders don't interact with it in physics
                player.box.GetComponent<Collider>().isTrigger = true;
                PlayerSoundController.PlayOneTime("grab");
            } else {
                player.grabbingItem = false;
                player.canTurn = true;
                player.playerSpeed = 20f;
                player.box.transform.SetParent(null, true);
                player.box.GetComponent<Rigidbody>().isKinematic = false;

                player.box.GetComponent<Collider>().isTrigger = false;

            }
    
        }
    }
}
