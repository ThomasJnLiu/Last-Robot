using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using JSAM;

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
                player.box.transform.position = (player.transform.forward *5f) + player.transform.position;
                player.box.transform.localRotation = Quaternion.Euler(0,0,0);
                player.box.GetComponent<Rigidbody>().isKinematic = true;

                // was having some buggy behaviour when the player's collider intersected with the box's collider
                // by setting the box collider to a trigger, it makes it so other colliders don't interact with it in physics
                player.box.GetComponent<Collider>().isTrigger = true;
                // PlayerSoundController.PlayOneTime("grab");
                // JSAM.AudioManager.PlaySound(Sounds.grabsfx);
            } else {
                player.grabbingItem = false;
                player.canTurn = true;
                if(player.box){
                    player.box.transform.SetParent(null, true);
                    player.box.GetComponent<Rigidbody>().isKinematic = false;

                    player.box.GetComponent<Collider>().isTrigger = false;
                }


            }
    
        }
    }
}
