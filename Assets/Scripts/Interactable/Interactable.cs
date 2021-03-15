using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Interactable : MonoBehaviour
{
    public enum State
    {
        Off,
        On,
        Broken
    }
        
    // Tag for context detection
    public string interactableTag;

    // Interactable state
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = interactableTag;
    }

    public abstract void Use(GameObject actor);

    public abstract void Reset(GameObject actor);

    public abstract void Fix(GameObject actor);

    public void Interact(GameObject actor)
    {
        switch (state)
        {
            case State.Broken:
                state = State.Off;
                Fix(actor);
                break;
            case State.Off:
                state = State.On;
                Use(actor);
                break;
            case State.On:
                state = State.Off;
                Reset(actor);
                break;
        }
    }
}
