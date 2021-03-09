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
        if (Input.GetKeyDown ("e") && player.interactable && player.interactable.interactableTag == "Box") {
            // Check if player is grabbing item
            if(player.interactable.state == Interactable.State.Off) {
                // Setting a lot of variables here, we could conslidate this into a function so it's a little cleaner, esp since these same variables
                // are also changed in the next else condition
                player.interactable.transform.SetParent(player.transform, true);
                player.interactable.transform.position = (player.transform.forward *5f) + player.transform.position;
                player.interactable.transform.localRotation = Quaternion.Euler(0,0,0);
                player.interactable.GetComponent<Rigidbody>().isKinematic = true;

                player.interactable.state = Interactable.State.On;

                // was having some buggy behaviour when the player's collider intersected with the box's collider
                // by setting the box collider to a trigger, it makes it so other colliders don't interact with it in physics
                player.interactable.GetComponent<Collider>().isTrigger = true;
                PlayerSoundController.PlayOneTime("grab");
            } else {
                if(player.interactable) {
                    player.interactable.transform.SetParent(null, true);
                    player.interactable.GetComponent<Rigidbody>().isKinematic = false;
                    player.interactable.GetComponent<Collider>().isTrigger = false;

                    player.interactable.state = Interactable.State.Off;
                }
            }
        }
    }
}
