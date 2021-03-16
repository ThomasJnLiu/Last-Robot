using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : PlayerInteractable
{
    public Interactable target;

    public override bool Use(GameObject actor)
    {
        if (actor.GetComponent<PlayerController>() != null) {
            target.Interact(gameObject);
            return true;
        }

        return false;
    }

    public override bool Reset(GameObject actor)
    {
        if (actor.GetComponent<PlayerController>() != null) {
            target.Interact(gameObject);
            return true;
        }

        return false;
    }
}
