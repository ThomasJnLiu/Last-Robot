using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : PlayerInteractable
{

    /*
     * Pick up the box.
     */
    public override bool Use(GameObject actor)
    {
        PlayerController player = actor.GetComponent<PlayerController>();
        PlayerInteraction playerInteraction = actor.GetComponent<PlayerInteraction>();

        if (playerInteraction.canInteract) {
            Debug.Log("Can Use");
            PlayerVisualChange.currentState = PlayerVisualChange.bodyStates.fullHold;
            transform.SetParent(player.transform, true);
            transform.position = (player.transform.forward *5f) + player.transform.position;
            transform.localRotation = Quaternion.Euler(0,0,0);
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().isTrigger = true;

            return true;
        } else {
            Debug.Log("Can't use");
        }

        return false;
    }

    public override bool Reset(GameObject actor)
    {
        transform.SetParent(null, true);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().isTrigger = false;
        PlayerVisualChange.currentState = PlayerVisualChange.bodyStates.full;
            
        return true;
    }
}
