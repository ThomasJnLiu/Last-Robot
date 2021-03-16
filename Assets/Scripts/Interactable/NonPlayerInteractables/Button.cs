using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : NonPlayerInteractable
{
    public Interactable target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Use(GameObject actor)
    {
        if (actor.GetComponent<PlayerController>() != null) {
            target.Interact(gameObject);
        }

        return false;
    }

    public override bool Reset(GameObject actor)
    {
        return true;
    }

    private void OnCollisionEnter (Collision collision)
    {
        target.Interact(gameObject);
    }
}
