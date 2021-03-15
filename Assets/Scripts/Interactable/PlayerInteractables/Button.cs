using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : PlayerInteractable
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

    public override void Use(GameObject actor)
    {
        if (actor.GetComponent<PlayerController>() != null) {
            target.Interact(gameObject);
            state = State.Off;
        }
    }

    public override void Reset(GameObject actor)
    {
        return;
    }
}
