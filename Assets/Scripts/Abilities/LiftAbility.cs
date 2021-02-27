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
                player.canTurn = false;
                player.playerSpeed = 5f;
                player.box.transform.SetParent(player.transform, true);
                player.box.GetComponent<Rigidbody>().isKinematic = true;
                PlayerSoundController.PlayOneTime("grab");
            } else {
                player.grabbingItem = false;
                player.canTurn = true;
                player.playerSpeed = 20f;
                player.box.transform.SetParent(null, true);
                player.box.GetComponent<Rigidbody>().isKinematic = false;
            }
    
        }
    }
}
